// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BracketsOperationRecognizer.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the BracketsOperationRecognizer type.
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
  /// The brackets operation recognizer.
  /// </summary>
  public class BracketsOperationRecognizer : IOperationRecognizer
  {
    /// <summary>
    /// The unary operation provider.
    /// </summary>
    private readonly IUnaryOperationProvider unaryOperationProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="BracketsOperationRecognizer"/> class.
    /// </summary>
    /// <param name="unaryOperationProvider">
    /// The unary operation provider.
    /// </param>
    public BracketsOperationRecognizer(IUnaryOperationProvider unaryOperationProvider)
    {
      this.unaryOperationProvider = unaryOperationProvider;
    }

    #region Implementation of IOperationRecognizer

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
      var rx = new Regex(@"^\(.*\)$");
      return rx.IsMatch(expression) && BracketChecker.CheckCorrectBrackets(expression) ? 0 : -1;
    }

    #endregion
  }
}
