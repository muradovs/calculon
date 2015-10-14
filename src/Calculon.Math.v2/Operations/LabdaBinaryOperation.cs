// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabdaBinaryOperation.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the LabdaBinaryOperation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Operations
{
  using System;

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
    /// <param name="op1">
    /// The op 1.
    /// </param>
    /// <param name="op2">
    /// The op 2.
    /// </param>
    public LabdaBinaryOperation(Func<double, double, double> func, IOperation op1, IOperation op2)
      : base(op1, op2)
    {
      this.func = func;
    }

    /// <summary>
    /// Gets the value.
    /// </summary>
    public override double Value
    {
      get
      {
        return this.func(this.Op1.Value, this.Op2.Value);
      }

      protected set
      {
        throw new NotImplementedException();
      }
    }
  }
}