// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBinaryOperationProvider.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the IBinaryOperationProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.OperationProviders
{
  using Calculon.Math.V2.Operations;

  /// <summary>
  /// The BinaryOperationProvider interface.
  /// </summary>
  public interface IBinaryOperationProvider
  {
    /// <summary>
    /// The get operation.
    /// </summary>
    /// <param name="op1">
    /// The op 1.
    /// </param>
    /// <param name="op2">
    /// The op 2.
    /// </param>
    /// <returns>
    /// The <see cref="IOperation"/>.
    /// </returns>
    IOperation GetOperation(IOperation op1, IOperation op2);
  }
}