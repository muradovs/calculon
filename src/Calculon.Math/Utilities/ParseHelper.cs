// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParseHelper.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   The parse helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.Utilities
{
  using System.Globalization;

  /// <summary>
  /// The parse helper.
  /// </summary>
  public static class ParseHelper
  {
    /// <summary>
    /// The try parse anyway.
    /// </summary>
    /// <param name="source">
    /// The source.
    /// </param>
    /// <param name="result">
    /// The result.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public static bool TryParseAnyway(this string source, out double result)
    {
      if (string.IsNullOrEmpty(source))
      {
        result = 0;
        return false;
      }

      /*if (source.IndexOf(',') != source.LastIndexOf(','))
      {
        result = 0;
        return false;
      }

      if (double.TryParse(source, NumberStyles.Any, CultureInfo.CurrentCulture, out result))
      {
        return true;
      }*/

      if (double.TryParse(source, out result))
      {
        return true;
      }

      if (double.TryParse(source, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result))
      {
        return true;
      }

      /*var newSource = source.Replace(',', '.');

      if (double.TryParse(newSource, NumberStyles.Any, CultureInfo.CurrentCulture, out result))
      {
        return true;
      }

      if (double.TryParse(newSource, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
      {
        return true;
      }*/

      return false;
    }
  }
}