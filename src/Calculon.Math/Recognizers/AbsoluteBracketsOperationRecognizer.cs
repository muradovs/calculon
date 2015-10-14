// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AbsoluteBracketsOperationRecognizer.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the AbsoluteBracketsOperationRecognizer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.Recognizers
{
  using System.Collections.Generic;
  using System.Text.RegularExpressions;

  using Calculon.Math.Executors;
  using Calculon.Math.Expressions;
  using Calculon.Math.OperationProviders;
  using Calculon.Math.Operations;
  using Calculon.Math.Utilities;

  /// <summary>
  /// The absolute brackets operation recognizer.
  /// </summary>
  public class AbsoluteBracketsOperationRecognizer : IOperationRecognizer
  {
    /// <summary>
    /// The operation provider.
    /// </summary>
    private readonly IUnaryOperationProvider operationProvider;

    #region Implementation of IOperationRecognizer

    /// <summary>
    /// Initializes a new instance of the <see cref="AbsoluteBracketsOperationRecognizer"/> class.
    /// </summary>
    /// <param name="operationProvider">
    /// The operation provider.
    /// </param>
    public AbsoluteBracketsOperationRecognizer(IUnaryOperationProvider operationProvider)
    {
      this.operationProvider = operationProvider;
    }

    /// <summary>
    /// The recognize.
    /// </summary>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <param name="operationExecutor">
    /// The operation executor.
    /// </param>
    /// <returns>
    /// The <see cref="IOperation"/>.
    /// </returns>
    public IOperation Recognize(string expression, IOperationExecutor operationExecutor)
    {
      if (this.Index(expression, operationExecutor) == 0)
      {
        var nexp = expression.Substring(1, expression.Length - 2);
        var bo = this.operationProvider.GetOperation(Expression.Create(nexp, operationExecutor));
        return bo;
      }

      return null;
    }

    /// <summary>
    /// The index.
    /// </summary>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <param name="operationExecutor">
    /// The operation executor.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public int Index(string expression, IOperationExecutor operationExecutor)
    {
      var rx = new Regex(@"^\|.*\|$");
      return rx.IsMatch(expression) ? 0 : -1;
    }

    /// <summary>
    /// The index of close bracket.
    /// </summary>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <param name="startBracket">
    /// The start bracket.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    private int IndexOfCloseBracket(string expression, int startBracket)
    {
      var num = 1;
      for (var i = (startBracket + 1); i < expression.Length; i++)
      {
        if (expression[i] == '|')
        {
          if (BracketChecker.IsAbsoluteBracketEnd(expression, i))
          {
            num--;
          }
          else
          {
            num++;
          }

          if (num == 0)
          {
            return i;
          }
        }
      }
      return -1;
    }

    private string[] GetDividedParts(string expression)
    {
      var result = new List<string>();

      //for (var i = 0; i < expression.Length; i++)
      //{
      //  if ()
      //}

      return result.ToArray();
    }

    #endregion
  }
}
