// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NumberOperationProvider.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the NumberOperationProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.OperationProviders
{
  using Calculon.Math.V2.Operations;

  /// <summary>
  /// The number operation provider.
  /// </summary>
  public class NumberOperationProvider : IUnaryOperationProvider
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
    public IOperation GetOperation(IOperation op)
    {
      return new NumberOperation(op);
    }
  }
}