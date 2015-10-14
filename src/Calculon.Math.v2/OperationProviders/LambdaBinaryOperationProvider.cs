// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LambdaBinaryOperationProvider.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   The lambda binary operation provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.OperationProviders
{
  using System;
  using Calculon.Math.V2.Operations;

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
    /// <param name="op1">
    /// The op 1.
    /// </param>
    /// <param name="op2">
    /// The op 2.
    /// </param>
    /// <returns>
    /// The <see cref="IOperation"/>.
    /// </returns>
    public IOperation GetOperation(IOperation op1, IOperation op2)
    {
      return new LabdaBinaryOperation(this.func, op1, op2);
    }
  }
}