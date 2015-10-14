// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BracketChecker.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the BracketChecker type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.Utilities
{
  using System;

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
      var result = CheckCorrectBrackets('(', ')', expression);
      var num = 0;
      for (var i = 0; i < expression.Length; i++)
      {
        if (expression[i] == '|')
        {
          num++;
        }
      }

      return result && (num % 2 == 0);
    }

    public static bool IsAbsoluteBracketEnd(string expression, int index)
    {
      if (index < 0 || index > expression.Length || expression[index] != '|')
      {
        throw new ArgumentException(index.ToString());
      }

      if (!CheckCorrectBrackets(expression))
      {
        throw new ArgumentException(expression);
      }

      if (index == 0) return false;
      if (index == expression.Length - 1) return true;
      var before = expression[index - 1];
      var after = expression[index + 1];
      if (char.IsDigit(before)) return true;
      if (char.IsDigit(after)) return false;

      if (expression.IndexOf('|') == index) return false;
      if (expression.LastIndexOf('|') == index) return true;

      return true;
    }
  }
}