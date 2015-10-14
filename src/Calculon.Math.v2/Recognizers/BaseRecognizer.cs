// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseRecognizer.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the BaseRecognizer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Recognizers
{
  using System.Collections.Generic;
  using System.Linq;
  using System.Text.RegularExpressions;

  using Calculon.Math.V2.Common;
  using Calculon.Math.V2.Operations;

  /// <summary>
  /// The base recognizer.
  /// </summary>
  public abstract class BaseRecognizer : IOperationRecognizer
  {
    /// <summary>
    /// The param pattern.
    /// </summary>
    private const string ParamPattern = @"{{exprId=([^}]*)}}";

    /// <summary>
    /// The pattern.
    /// </summary>
    private readonly string[] patterns;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseRecognizer"/> class.
    /// </summary>
    /// <param name="patterns">
    /// The pattern.
    /// </param>
    protected BaseRecognizer(string[] patterns)
    {
      this.patterns = patterns;
    }

    /// <summary>
    /// The recognize.
    /// </summary>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <param name="operations">
    /// The operations.
    /// </param>
    /// <returns>
    /// The <see cref="RecognizedData"/>.
    /// </returns>
    public abstract RecognizedData Recognize(string expression, IDictionary<string, IOperation> operations);

    /// <summary>
    /// The index.
    /// </summary>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <returns>
    /// The <see cref="Span"/>.
    /// </returns>
    public Span Index(string expression)
    {
      return this.patterns.Select(pattern => Index(expression, pattern)).FirstOrDefault(span => span != null);
    }

    /// <summary>
    /// The to string.
    /// </summary>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    public override string ToString()
    {
      return this.patterns.Aggregate((x, y) => x + System.Environment.NewLine + y);
    }

    /// <summary>
    /// The create result.
    /// </summary>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <param name="span">
    /// The span.
    /// </param>
    /// <param name="operation">
    /// The operation.
    /// </param>
    /// <returns>
    /// The <see cref="RecognizedData"/>.
    /// </returns>
    protected RecognizedData CreateResult(string expression, Span span, IOperation operation)
    {
      var newValue = string.Format(@"{{{{exprId={0}}}}}", operation.Id);
      var res = expression.Substring(0, span.StartIndex) + newValue
                + expression.Substring(span.StartIndex + span.Length, expression.Length - span.StartIndex - span.Length);
      return new RecognizedData(operation, res);
    }

    /// <summary>
    /// The get params.
    /// </summary>
    /// <param name="fragment">
    /// The fragment.
    /// </param>
    /// <returns>
    /// The <see>
    ///       <cref>string[]</cref>
    ///     </see>
    ///   .
    /// </returns>
    protected string[] GetParams(string fragment)
    {
      var regex = new Regex(ParamPattern);
      var matches = regex.Matches(fragment);
      return (from Match match in matches 
              where match.Groups.Count > 1
              select match.Groups[1].Value).ToArray();
    }

    /// <summary>
    /// The index.
    /// </summary>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <param name="pattern">
    /// The pattern.
    /// </param>
    /// <returns>
    /// The <see cref="Span"/>.
    /// </returns>
    private static Span Index(string expression, string pattern)
    {
      var regex = new Regex(pattern);

      if (regex.IsMatch(expression))
      {
        var matches = regex.Matches(expression);
        foreach (Match match in matches)
        {
          if (CheckIndex(expression, match.Index))
          {
            if (match.Groups.Count > 1)
            {
              var group = match.Groups[1];
              return new Span(group.Index, group.Length, group.Value);
            }
          }
        }
      }

      return null;
    }

    /// <summary>
    /// The check index.
    /// </summary>
    /// <param name="exp">
    /// The exp.
    /// </param>
    /// <param name="index">
    /// The index.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    private static bool CheckIndex(string exp, int index)
    {
      int count = 0;
      for (var i = index; i < exp.Length; i++)
      {
        if (exp[i] == '}')
        {
          count++;
        }

        if (exp[i] == '{')
        {
          count--;
        }
      }

      return count < 2;
    }
  }
}