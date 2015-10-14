// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabdaUnaryOperation.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the LabdaUnaryOperation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.Operations
{
  using System;

  using Calculon.Math.Expressions;

  /// <summary>
  /// The labda unary operation.
  /// </summary>
  public class LabdaUnaryOperation : UnaryOperation
  {
    /// <summary>
    /// The _func.
    /// </summary>
    private readonly Func<double, double> func;

    /// <summary>
    /// Initializes a new instance of the <see cref="LabdaUnaryOperation"/> class.
    /// </summary>
    /// <param name="func">
    /// The func.
    /// </param>
    /// <param name="exp">
    /// The exp.
    /// </param>
    public LabdaUnaryOperation(Func<double, double> func, IExpression exp)
      : base(exp)
    {
      this.func = func;
    }

    /// <summary>
    /// Gets the value.
    /// </summary>
    public override double Value
    {
      get { return this.func(Ex.Value); }
    }
  }
}