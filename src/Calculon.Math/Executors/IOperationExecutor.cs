// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOperationExecutor.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the IOperationExecutor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace Calculon.Math.Executors
{
  using Calculon.Math.Operations;

  /// <summary>
  /// The OperationExecutor interface.
  /// </summary>
  public interface IOperationExecutor
    {
    /// <summary>
    /// The get operation.
    /// </summary>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <returns>
    /// The <see cref="IOperation"/>.
    /// </returns>
    IOperation GetOperation(string expression);
    }
}