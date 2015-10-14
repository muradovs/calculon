// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryOperation.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the BinaryOperation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Operations
{
  /// <summary>
  /// The binary operation.
  /// </summary>
  public abstract class BinaryOperation : BaseOperation
  {
    /// <summary>
    /// The op 1.
    /// </summary>
    protected readonly IOperation Op1;

    /// <summary>
    /// The op 2.
    /// </summary>
    protected readonly IOperation Op2;

    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryOperation"/> class.
    /// </summary>
    /// <param name="op1">
    /// The exp 1.
    /// </param>
    /// <param name="op2">
    /// The exp 2.
    /// </param>
    protected BinaryOperation(IOperation op1, IOperation op2)
    {
      this.Op1 = op1;
      this.Op2 = op2;
    }
  }
}