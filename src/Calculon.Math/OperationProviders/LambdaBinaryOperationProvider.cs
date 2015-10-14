// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LambdaBinaryOperationProvider.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   The lambda binary operation provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.OperationProviders
{
  using System;

  using Calculon.Math.Expressions;
  using Calculon.Math.Operations;

  /// <summary>
  /// The lambda binary operation provider.
  /// </summary>
  public class LambdaBinaryOperationProvider : IBinaryOperationProvider
  {
    /// <summary>
    /// The _func.
    /// </summary>
    private readonly Func<double, double, double> func;

    /// <summary>
    /// Initializes a new instance of the <see cref="LambdaBinaryOperationProvider"/> class.
    /// </summary>
    /// <param name="func">
    /// The func.
    /// </param>
    public LambdaBinaryOperationProvider(Func<double, double, double> func)
    {
      this.func = func;
    }

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
    public IOperation GetOperation(IExpression exp1, IExpression exp2)
    {
      return new LabdaBinaryOperation(this.func, exp1, exp2);
    }
  }
}