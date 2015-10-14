// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BracketChecker.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the BracketChecker type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Utilities
{
  /// <summary>
  /// The bracket checker.
  /// </summary>
  public class BracketChecker
  {
    /// <summary>
    /// The check correct brackets.
    /// </summary>
    /// <param name="leftBracket">
    /// The left bracket.
    /// </param>
    /// <param name="rightBracket">
    /// The right bracket.
    /// </param>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public static bool CheckCorrectBrackets(char leftBracket, char rightBracket, string expression)
    {
      var value = 0;

      for (var i = 0; i < expression.Length; i++)
      {
        var c = expression[i];

        if (c == leftBracket)
        {
          value++;
        }
      
        if (c == rightBracket)
        {
          if (value == 0)
          {
            return false;
          }

          value--;
        }
      }

      return value == 0;
    }

    /// <summary>
    /// The check correct brackets.
    /// </summary>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public static bool CheckCorrectBrackets(string expression)
    {
      return CheckCorrectBrackets('(', ')', expression);
    }
  }
}