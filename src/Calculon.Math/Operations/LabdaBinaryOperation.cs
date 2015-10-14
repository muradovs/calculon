// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabdaBinaryOperation.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the LabdaBinaryOperation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.Operations
{
  using System;

  using Calculon.Math.Expressions;

  /// <summary>
  /// The labda binary operation.
  /// </summary>
  public class LabdaBinaryOperation : BinaryOperation
  {
    /// <summary>
    /// The func.
    /// </summary>
    private readonly Func<double, double, double> func;

    /// <summary>
    /// Initializes a new instance of the <see cref="LabdaBinaryOperation"/> class.
    /// </summary>
    /// <param name="func">
    /// The func.
    /// </param>
    /// <param name="exp1">
    /// The exp 1.
    /// </param>
    /// <param name="exp2">
    /// The exp 2.
    /// </param>
    public LabdaBinaryOperation(Func<double, double, double> func, IExpression exp1, IExpression exp2)
      : base(exp1, exp2)
    {
      this.func = func;
    }

    /// <summary>
    /// Gets the value.
    /// </summary>
    public override double Value
    {
      get { return this.func(Ex1.Value, Ex2.Value); }
    }
  }
}