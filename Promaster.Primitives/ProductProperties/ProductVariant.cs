using System;

namespace Promaster.Primitives.ProductProperties
{
  /// <summary>
  /// Represents a products identification and its selected property values.
  /// IMPORTANT: Keep this class immutable!
  /// </summary>
  public class ProductVariant
  {
    private static readonly ProductVariant Empty = new ProductVariant();

    private readonly string _productId;
    private readonly PropertyValueSet _properties;

    // Private because only used to create the single Empty instance
    private ProductVariant()
    {
      _productId = string.Empty;
      _properties = PropertyValueSet.Empty;
    }

    public ProductVariant(string productId, PropertyValueSet properties)
    {
      _productId = productId;
      _properties = properties;
    }

    public string ProductId
    {
      get { return _productId; }
    }

    public PropertyValueSet Properties
    {
      get { return _properties; }
    }

    public static ProductVariant ParseOrDefault(string encodedValue, ProductVariant defaultValue)
    {
      ProductVariant result;
      if (TryParse(encodedValue, out result))
      {
        return result;
      }
      else
      {
        return defaultValue;
      }
    }

    public static ProductVariant Parse(string encodedValue)
    {
      ProductVariant result;
      if (TryParse(encodedValue, out result))
      {
        return result;
      }
      else
      {
        throw new InvalidOperationException("Invalid string. Use TryParse() or ParseOrDefault() to do parsing without exceptions.");
      }
    }

    public static bool TryParse(string encodedValue, out ProductVariant productVariant)
    {
      if (string.IsNullOrEmpty(encodedValue))
      {
        productVariant = Empty;
        return true;
      }

      // Format of encoded value is ProductId;PropertyValueSet
      var firstSemicolonIndex = encodedValue.IndexOf(';');
      if (firstSemicolonIndex <= 0)
      {
        productVariant = default(ProductVariant);
        return false;
      }

      var productId = encodedValue.Substring(0, firstSemicolonIndex);
      var propertyValueSetString = encodedValue.Substring(firstSemicolonIndex + 1);
      PropertyValueSet propertyValueSet;
      if (!PropertyValueSet.TryParse(propertyValueSetString, out propertyValueSet))
      {
        productVariant = default(ProductVariant);
        return false;
      }

      productVariant = new ProductVariant(productId, propertyValueSet);
      return true;
    }

    public override string ToString()
    {
      return string.Format("{0};{1}", _productId, _properties);
    }

    public bool Equals(ProductVariant other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return Equals(other.GetLowerCaseProductId(), GetLowerCaseProductId()) && Equals(other._properties, _properties);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != typeof(ProductVariant)) return false;
      return Equals((ProductVariant)obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return ((GetLowerCaseProductId() != null ? GetLowerCaseProductId().GetHashCode() : 0) * 397) ^ (_properties != null ? _properties.GetHashCode() : 0);
      }
    }

    private string GetLowerCaseProductId()
    {
      return _productId == null ? null : _productId.ToLower();
    }

  }

}
