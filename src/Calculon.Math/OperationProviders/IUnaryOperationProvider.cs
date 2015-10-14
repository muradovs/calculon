// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnaryOperationProvider.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the IUnaryOperationProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.OperationProviders
{
  using Calculon.Math.Expressions;
  using Calculon.Math.Operations;

  /// <summary>
  /// The UnaryOperationProvider interface.
  /// </summary>
  public interface IUnaryOperationProvider
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
    IOperation GetOperation(IExpression exp);
  }
}