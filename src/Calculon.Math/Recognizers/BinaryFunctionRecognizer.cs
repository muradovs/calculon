// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryFunctionRecognizer.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   The binary function recognizer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.Recognizers
{
  using System.Text.RegularExpressions;

  using Calculon.Math.Executors;
  using Calculon.Math.Expressions;
  using Calculon.Math.OperationProviders;
  using Calculon.Math.Operations;
  using Calculon.Math.Utilities;

  /// <summary>
  /// The binary function recognizer.
  /// </summary>
  public class BinaryFunctionRecognizer : IOperationRecognizer
  {
    /// <summary>
    /// The _function name.
    /// </summary>
    private readonly string functionName;

    /// <summary>
    /// The _unary operation provider.
    /// </summary>
    private readonly IBinaryOperationProvider operationProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryFunctionRecognizer"/> class.
    /// </summary>
    /// <param name="functionName">
    /// The function name.
    /// </param>
    /// <param name="operationProvider">
    /// The operation provider.
    /// </param>
    public BinaryFunctionRecognizer(string functionName, IBinaryOperationProvider operationProvider)
    {
      this.functionName = functionName;
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
        var len = this.functionName.Length;
        var exp = expression.Substring(len + 1, expression.Length - len - 2);
        var spos = this.FindFirstCorrectIndexOf(exp, ',') + len + 1;
        var nexp1 = expression.Substring(1 + len, spos - 1 - len);
        var nexp2 = expression.Substring(spos + 1, expression.Length - 1 - spos - 1);
        var bo = this.operationProvider.GetOperation(
          Expression.Create(nexp1, operationExecutor), Expression.Create(nexp2, operationExecutor));
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
      var rx = new Regex(@"^" + this.functionName + @"\(.*,.*\)$");
      var result = rx.IsMatch(expression) && BracketChecker.CheckCorrectBrackets(expression) ? 0 : -1;
      return result;
    }

    /// <summary>
    /// The find first correct index of.
    /// </summary>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <param name="token">
    /// The token.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public int FindFirstCorrectIndexOf(string expression, char token)
    {
      var tempExp = expression;
      for (var i = 0; i < expression.Length; i++)
      {
        if (expression[i] == token)
        {
          var index = i;
          var firstRow = tempExp.Substring(0, index);
          var secondRow = tempExp.Substring(index, tempExp.Length - index - 1);

          if (BracketChecker.CheckCorrectBrackets(firstRow) && BracketChecker.CheckCorrectBrackets(secondRow))
          {
            return index;
          }
        }
      }

      return -1;
    }
  }
}