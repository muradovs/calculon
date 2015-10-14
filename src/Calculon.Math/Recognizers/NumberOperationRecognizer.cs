// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NumberOperationRecognizer.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the NumberOperationRecognizer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.Recognizers
{
  using System.Globalization;
  using Calculon.Math.Executors;
  using Calculon.Math.Expressions;
  using Calculon.Math.OperationProviders;
  using Calculon.Math.Operations;
  using Calculon.Math.Utilities;

  /// <summary>
  /// The number operation recognizer.
  /// </summary>
  public class NumberOperationRecognizer : IOperationRecognizer
  {
    /// <summary>
    /// The operation provider.
    /// </summary>
    private readonly IUnaryOperationProvider operationProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="NumberOperationRecognizer"/> class.
    /// </summary>
    /// <param name="operationProvider">
    /// The operation provider.
    /// </param>
    public NumberOperationRecognizer(IUnaryOperationProvider operationProvider)
    {
      this.operationProvider = operationProvider;
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
      var exp = Expression.Create(expression, operationExecutor);
      return this.operationProvider.GetOperation(exp);
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
      if (CheckOperation(expression))
      {
        return 0;
      }

      return -1;
    }

    /// <summary>
    /// The check operation.
    /// </summary>
    /// <param name="op">
    /// The op.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    private static bool CheckOperation(string op)
    {
      double result;
      return op.TryParseAnyway(out result);
    }

    #endregion
  }
}
