using System.Collections.Generic;
using Promaster.Primitives.PropertyFiltering.Ast;



using System;

namespace Promaster.Primitives.PropertyFiltering.Parsing {



internal class Parser {
	public const int _EOF = 0;
	public const int _ident = 1;
	public const int _propval = 2;
	public const int maxT = 22;

	const bool T = true;
	const bool x = false;
	const int minErrDist = 2;
	
	public Scanner scanner;
	public Errors  errors;

	public Token t;    // last recognized token
	public Token la;   // lookahead token
	int errDist = minErrDist;

private Expr _root;

public Expr GetRoot() { return _root; }

private ComparisonOperationType StringToComparisonOperationType(string str)
{
  if (str == ">") return ComparisonOperationType.Greater;
  if (str == "<") return ComparisonOperationType.Less;
  if (str == ">=") return ComparisonOperationType.GreaterOrEqual;
  return ComparisonOperationType.LessOrEqual;
}

private EqualsOperationType StringToEqualsOperationType(string str)
{
  if (str == "=") return EqualsOperationType.Equals;
  return EqualsOperationType.NotEquals;
}



	public Parser(Scanner scanner) {
		this.scanner = scanner;
		errors = new Errors();
	}

	void SynErr (int n) {
		if (errDist >= minErrDist) errors.SynErr(la.line, la.col, n);
		errDist = 0;
	}

	public void SemErr (string msg) {
		if (errDist >= minErrDist) errors.SemErr(t.line, t.col, msg);
		errDist = 0;
	}
	
	void Get () {
		for (;;) {
			t = la;
			la = scanner.Scan();
			if (la.kind <= maxT) { ++errDist; break; }

			la = t;
		}
	}
	
	void Expect (int n) {
		if (la.kind==n) Get(); else { SynErr(n); }
	}
	
	bool StartOf (int s) {
		return set[s, la.kind];
	}
	
	void ExpectWeak (int n, int follow) {
		if (la.kind == n) Get();
		else {
			SynErr(n);
			while (!StartOf(follow)) Get();
		}
	}


	bool WeakSeparator(int n, int syFol, int repFol) {
		int kind = la.kind;
		if (kind == n) {Get(); return true;}
		else if (StartOf(repFol)) {return false;}
		else {
			SynErr(n);
			while (!(set[syFol, kind] || set[repFol, kind] || set[0, kind])) {
				Get();
				kind = la.kind;
			}
			return StartOf(syFol);
		}
	}

	
	void PropertyFilter() {
		OrExpr(out _root);
	}

	void OrExpr(out Expr expr) {
		var children = new List<Expr>(); Expr e; 
		AndExpr(out e);
		children.Add(e); 
		while (la.kind == 3) {
			Get();
			AndExpr(out e);
			children.Add(e); 
		}
		expr = children.Count == 1 ? children[0] : new OrExpr(children); 
	}

	void AndExpr(out Expr expr) {
		var children = new List<Expr>(); Expr e; 
		Expr(out e);
		children.Add(e); 
		while (la.kind == 4) {
			Get();
			Expr(out e);
			children.Add(e); 
		}
		expr = children.Count == 1 ? children[0] : new AndExpr(children); 
	}

	void Expr(out Expr expr) {
		expr = null; 
		if (la.kind == 5) {
			Get();
			OrExpr(out expr);
			Expect(6);
		} else if (StartOf(1)) {
			ComparisonExpr(out expr);
		} else SynErr(23);
	}

	void ComparisonExpr(out Expr expr) {
		expr = null; Expr lh; 
		AddExpr(out lh);
		if (StartOf(2)) {
			Expr rh; 
			if (la.kind == 7) {
				Get();
			} else if (la.kind == 8) {
				Get();
			} else if (la.kind == 9) {
				Get();
			} else {
				Get();
			}
			var opType = StringToComparisonOperationType(t.val); 
			AddExpr(out rh);
			expr = new ComparisonExpr(lh, opType, rh); 
		} else if (la.kind == 11 || la.kind == 12) {
			Expr r; var list = new List<Expr>(); 
			if (la.kind == 11) {
				Get();
			} else {
				Get();
			}
			var opType = StringToEqualsOperationType(t.val); 
			ValueRangeExpr(out r);
			list.Add(r); 
			while (la.kind == 13) {
				Get();
				ValueRangeExpr(out r);
				list.Add(r); 
			}
			expr = new EqualsExpr(lh, opType, list); 
		} else SynErr(24);
	}

	void AddExpr(out Expr e) {
		AddOperator op; Expr e2; 
		MultiplyExpr(out e);
		while (la.kind == 15 || la.kind == 16) {
			if (la.kind == 15) {
				Get();
				op = AddOperator.Plus; 
			} else {
				Get();
				op = AddOperator.Minus; 
			}
			MultiplyExpr(out e2);
			e = new AddExpr(e, op, e2); 
		}
	}

	void ValueRangeExpr(out Expr val) {
		val = null; Expr v1; Expr v2; 
		AddExpr(out v1);
		if (la.kind == 14) {
			Get();
			AddExpr(out v2);
			val = new ValueRangeExpr(v1, v2); 
		}
		if (val == null) val = new ValueRangeExpr(v1, v1); 
	}

	void MultiplyExpr(out Expr e) {
		MultiplyOperator op; Expr e2; 
		UnaryExpr(out e);
		while (la.kind == 17 || la.kind == 18 || la.kind == 19) {
			if (la.kind == 17) {
				Get();
				op = MultiplyOperator.Times; 
			} else if (la.kind == 18) {
				Get();
				op = MultiplyOperator.Divide; 
			} else {
				Get();
				op = MultiplyOperator.Modulo; 
			}
			UnaryExpr(out e2);
			e = new MultiplyExpr(e, op, e2); 
		}
	}

	void UnaryExpr(out Expr e) {
		e = null; 
		if (la.kind == 16) {
			UnaryOperator op; 
			Get();
			op = UnaryOperator.Minus; 
			ValueExpr(out e);
			e = new UnaryExpr(op, e); 
		} else if (la.kind == 1 || la.kind == 2 || la.kind == 20) {
			ValueExpr(out e);
		} else SynErr(25);
	}

	void ValueExpr(out Expr val) {
		val = null; string s = null; 
		if (la.kind == 20) {
			Get();
			val = new NullExpr(); 
		} else if (la.kind == 1) {
			Get();
			val = new IdentifierExpr(t.val); s = t.val; 
			if (la.kind == 21) {
				Get();
				Expect(1);
				val = new IdentifierAsExpr(s, t.val); 
			}
		} else if (la.kind == 2) {
			Get();
			val = new ValueExpr(t.val); 
		} else SynErr(26);
	}



	public void Parse() {
		la = new Token();
		la.val = "";		
		Get();
		PropertyFilter();
		Expect(0);

	}
	
	static readonly bool[,] set = {
		{T,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x, x,x,x,x},
		{x,T,T,x, x,x,x,x, x,x,x,x, x,x,x,x, T,x,x,x, T,x,x,x},
		{x,x,x,x, x,x,x,T, T,T,T,x, x,x,x,x, x,x,x,x, x,x,x,x}

	};
} // end Parser


internal class Errors {
	public int count = 0;                                    // number of errors detected
	public System.IO.TextWriter errorStream = new System.IO.StringWriter();   // error messages go to this stream
	public string errMsgFormat = "-- line {0} col {1}: {2}"; // 0=line, 1=column, 2=text

	public virtual void SynErr (int line, int col, int n) {
		string s;
		switch (n) {
			case 0: s = "EOF expected"; break;
			case 1: s = "ident expected"; break;
			case 2: s = "propval expected"; break;
			case 3: s = "\"|\" expected"; break;
			case 4: s = "\"&\" expected"; break;
			case 5: s = "\"(\" expected"; break;
			case 6: s = "\")\" expected"; break;
			case 7: s = "\">\" expected"; break;
			case 8: s = "\"<\" expected"; break;
			case 9: s = "\">=\" expected"; break;
			case 10: s = "\"<=\" expected"; break;
			case 11: s = "\"=\" expected"; break;
			case 12: s = "\"!=\" expected"; break;
			case 13: s = "\",\" expected"; break;
			case 14: s = "\"~\" expected"; break;
			case 15: s = "\"+\" expected"; break;
			case 16: s = "\"-\" expected"; break;
			case 17: s = "\"*\" expected"; break;
			case 18: s = "\"/\" expected"; break;
			case 19: s = "\"%\" expected"; break;
			case 20: s = "\"null\" expected"; break;
			case 21: s = "\":\" expected"; break;
			case 22: s = "??? expected"; break;
			case 23: s = "invalid Expr"; break;
			case 24: s = "invalid ComparisonExpr"; break;
			case 25: s = "invalid UnaryExpr"; break;
			case 26: s = "invalid ValueExpr"; break;

			default: s = "error " + n; break;
		}
		errorStream.WriteLine(errMsgFormat, line, col, s);
		count++;
	}

	public virtual void SemErr (int line, int col, string s) {
		errorStream.WriteLine(errMsgFormat, line, col, s);
		count++;
	}
	
	public virtual void SemErr (string s) {
		errorStream.WriteLine(s);
		count++;
	}
	
	public virtual void Warning (int line, int col, string s) {
		errorStream.WriteLine(errMsgFormat, line, col, s);
	}
	
	public virtual void Warning(string s) {
		errorStream.WriteLine(s);
	}
} // Errors


internal class FatalError: Exception {
	public FatalError(string m): base(m) {}
}
}