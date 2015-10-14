// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LambdaUnaryOperationProvider.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   The lambda unary operation provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.OperationProviders
{
  using System;

  using Calculon.Math.Expressions;
  using Calculon.Math.Operations;

  /// <summary>
  /// The lambda unary operation provider.
  /// </summary>
  public class LambdaUnaryOperationProvider : IUnaryOperationProvider
  {
    /// <summary>
    /// The _func.
    /// </summary>
    private readonly Func<double, double> func;

    /// <summary>
    /// Initializes a new instance of the <see cref="LambdaUnaryOperationProvider"/> class.
    /// </summary>
    /// <param name="func">
    /// The func.
    /// </param>
    public LambdaUnaryOperationProvider(Func<double, double> func)
    {
      this.func = func;
    }

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
      return new LabdaUnaryOperation(this.func, exp);
    }
  }
}