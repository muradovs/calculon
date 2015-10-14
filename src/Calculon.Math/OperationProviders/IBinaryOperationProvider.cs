// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBinaryOperationProvider.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the IBinaryOperationProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.OperationProviders
{
  using Calculon.Math.Expressions;
  using Calculon.Math.Operations;

  /// <summary>
  /// The BinaryOperationProvider interface.
  /// </summary>
  public interface IBinaryOperationProvider
  {
    /// <summary>
    /// The get operation.
    /// </summary>
    /// <param name="exp1">
    /// The exp 1.
    /// </param>
    /// <param name="exp2">
    /// The exp 2.
    /// </param>
    /// <returns>
    /// The <see cref="IOperation"/>.
    /// </returns>
    IOperation GetOperation(IExpression exp1, IExpression exp2);
  }
}