// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnaryOperationProvider.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the IUnaryOperationProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.OperationProviders
{
  using Calculon.Math.V2.Operations;

  /// <summary>
  /// The UnaryOperationProvider interface.
  /// </summary>
  public interface IUnaryOperationProvider
  {
    /// <summary>
    /// The get operation.
    /// </summary>
    /// <param name="op">
    /// The op.
    /// </param>
    /// <returns>
    /// The <see cref="IOperation"/>.
    /// </returns>
    IOperation GetOperation(IOperation op);
  }
}