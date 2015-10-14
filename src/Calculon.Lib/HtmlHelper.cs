// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlHelper.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the HtmlHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Lib
{
  using System.Text.RegularExpressions;

  /// <summary>
  /// The html helper.
  /// </summary>
  public class HtmlHelper
  {
    /// <summary>
    /// The remove tags.
    /// </summary>
    /// <param name="htmlText">
    /// The html text.
    /// </param>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    public static string RemoveTags(string htmlText)
     {
       var html = GetHtmlFromSharing(htmlText);
       var expression = new Regex("(<[^>]*>)|([^{]*{[^}]*})", RegexOptions.IgnoreCase);
       var result = expression.Replace(html, string.Empty).Trim('\n', '\r', ' ');
       return result;
     }

    /// <summary>
    /// The get html from sharing.
    /// </summary>
    /// <param name="sharingText">
    /// The sharing text.
    /// </param>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    private static string GetHtmlFromSharing(string sharingText)
    {
      var start = sharingText.IndexOf("<!--StartFragment -->", System.StringComparison.Ordinal) + "<!--StartFragment -->".Length;
      var end = sharingText.IndexOf("<!--EndFragment -->", System.StringComparison.Ordinal);
      if (start > -1 && end > start)
      {
        return sharingText.Substring(start, end - start);
      }

      return sharingText;
    }
  }
}