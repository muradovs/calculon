// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnaryFunctionRecognizer.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the UnaryFunctionRecognizer type.
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
  /// The unary function recognizer.
  /// </summary>
  public class UnaryFunctionRecognizer : IOperationRecognizer
  {
    /// <summary>
    /// The _function name.
    /// </summary>
    private readonly string functionName;

    /// <summary>
    /// The _unary operation provider.
    /// </summary>
    private readonly IUnaryOperationProvider unaryOperationProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnaryFunctionRecognizer"/> class.
    /// </summary>
    /// <param name="functionName">
    /// The function name.
    /// </param>
    /// <param name="unaryOperationProvider">
    /// The unary operation provider.
    /// </param>
    public UnaryFunctionRecognizer(string functionName, IUnaryOperationProvider unaryOperationProvider)
    {
      this.functionName = functionName;
      this.unaryOperationProvider = unaryOperationProvider;
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
        var nexp = expression.Substring(1 + len, expression.Length - 2 - len);
        var bo = this.unaryOperationProvider.GetOperation(Expression.Create(nexp, operationExecutor));
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
      var rx = new Regex(@"^" + this.functionName + @"\(.*\)$");
      var result = rx.IsMatch(expression) && BracketChecker.CheckCorrectBrackets(expression) ? 0 : -1;
      return result;
    }
  }
}