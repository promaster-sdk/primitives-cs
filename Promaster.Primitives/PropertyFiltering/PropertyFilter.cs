using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Promaster.Primitives.Measure;
using Promaster.Primitives.Measure.Unit;
using Promaster.Primitives.Portable.FloatingPoint;
using Promaster.Primitives.ProductProperties;
using Promaster.Primitives.PropertyFiltering.Ast;
using Promaster.Primitives.PropertyFiltering.Compilation;
using Promaster.Primitives.PropertyFiltering.Evaluation;
using Promaster.Primitives.PropertyFiltering.Parsing;

namespace Promaster.Primitives.PropertyFiltering
{
  [DebuggerDisplay("PropertyFilter ({_text})")]
  public class PropertyFilter
  {
    public static readonly PropertyFilter Empty = new PropertyFilter();

    private readonly string _text;
    private readonly Expr _ast;
    private readonly CompiledFilter _compiled;

    private PropertyFilter()
      : this(null, new EmptyExpr(), (func, func2) => true)
    {
    }

    private PropertyFilter(string text, Expr ast, CompiledFilter compiled)
    {
      _text = text;
      _ast = ast;
      _compiled = compiled;
    }

    // Do not use this!! Use PropertyFilterFactory instead so we use caching. 
    // Compiling PropertyFilters is expensive stuff and we cannot put a cache here since ICacheManager is not part of Primitives.
    public static PropertyFilter Create(string filter)
    {
      var adjustedFilter = PreProcessString(filter);
      if (adjustedFilter == null)
        return Empty;

      var ast = BuildAst(adjustedFilter, true);

      var compiled = CompileAst(ast);

      return new PropertyFilter(adjustedFilter, ast, compiled);
    }

    public Expr Ast
    {
      get { return _ast; }
    }

    #region Public

    public static bool IsSyntaxValid(string filter)
    {
      var adjusted = PreProcessString(filter);
      if (adjusted == null)
        return true;

      return BuildAst(adjusted, false) != null;
    }

    public bool IsValid(PropertyValueSet properties, bool matchMissing = false)
    {
      if (matchMissing)
        return new FilterEvaluator().Evaluate(_ast, properties, matchMissing);
      return _compiled(propertyName => LookupPropertyValue(properties, propertyName), ((propertyName, unit) => LookupPropertyValue(properties, propertyName, unit)));
    }

    public override int GetHashCode()
    {
      return _text.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(this, obj))
        return true;
      if (obj == null)
        return false;
      if (GetType() != obj.GetType())
        return false;
      var other = (PropertyFilter)obj;
      return _text == other._text;
    }

    public override string ToString()
    {
      return _text;
    }

    #endregion

    #region Private

    /// <summary>
    ///   Guarantees that all empty strings will be null, all characters will be lower case, and old syntax is supported
    /// </summary>
    private static string PreProcessString(string filter)
    {
      if (string.IsNullOrEmpty(filter) || filter.Trim().Length == 0)
        return null;

      filter = filter.Trim().ToLower();

      // Adjust for old syntax
      if (filter.EndsWith(";") /*filter like a=1;...;b=2;*/|| filter.EndsWith(";}" /* filter like {a=1;}{...;}{z=5;}*/))
      {
        filter = filter.TrimEnd(new[] { ';' }).Replace(";}", "}").Replace(";)", ")").Replace(';', '&');
        filter = filter.Replace("}{", ")|(").Replace("{", "(").Replace("}", ")");
      }
      return filter;
    }

    private static Expr BuildAst(string text, bool throwOnInvalidSyntax)
    {
      if (text == null)
        throw new ArgumentNullException("text");

      var memoryStream = new MemoryStream(new UTF8Encoding().GetBytes(text));
      var scanner = new Scanner(memoryStream);
      var parser = new Parser(scanner);
      parser.Parse();
      if (parser.errors.count > 0)
      {
        if (throwOnInvalidSyntax)
          throw new Exception(string.Format("Syntax of PropertyFilter '{0}' is not valid.", text));
        return null;
      }

      return parser.GetRoot();
    }

    private static CompiledFilter CompileAst(Expr ast)
    {
      var compiler = new FilterToLambaCompiler();
      return compiler.Compile(ast);
    }

    private PropertyValue LookupPropertyValue(PropertyValueSet pvs, string propertyName, string unitStr = null)
    {
      PropertyValue value;
      if (pvs != null && pvs.TryGetValue(propertyName, out value))
      {
        if(unitStr == null)
          return value;

        var intVal = value.ToInteger();
        var unit = Units.Parse(unitStr);
        return new PropertyValue(Amount.Exact(intVal, unit));
      }
      return null;
    }

    #endregion
  }

}
