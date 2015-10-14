// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOperationRecognizer.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the IOperationRecognizer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.Recognizers
{
  using Calculon.Math.Executors;
  using Calculon.Math.Operations;

  /// <summary>
  /// The OperationRecognizer interface.
  /// </summary>
  public interface IOperationRecognizer
  {
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
    IOperation Recognize(string expression, IOperationExecutor operationExecutor);

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
    int Index(string expression, IOperationExecutor operationExecutor);
  }
}
