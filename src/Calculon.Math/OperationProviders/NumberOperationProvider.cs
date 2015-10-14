// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NumberOperationProvider.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the NumberOperationProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.OperationProviders
{
  using Calculon.Math.Expressions;
  using Calculon.Math.Operations;

  /// <summary>
  /// The number operation provider.
  /// </summary>
  public class NumberOperationProvider : IUnaryOperationProvider
  {
    /// <summary>
    /// The get operation.
    /// </summary>
    /// <param name="exp">
    /// The exp.
    /// </param>
    /// <returns>
    /// The <see cref="IOperation"/>.
    /// </returns>
    public IOperation GetOperation(IExpression exp)
    {
      return new NumberOperation(exp);
    }
  }
}