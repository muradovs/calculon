// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnaryOperation.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the UnaryOperation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Operations
{
  /// <summary>
  /// The unary operation.
  /// </summary>
  public abstract class UnaryOperation : BaseOperation
  {
    /// <summary>
    /// The op.
    /// </summary>
    protected readonly IOperation Op;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnaryOperation"/> class.
    /// </summary>
    /// <param name="op">
    /// The ex.
    /// </param>
    protected UnaryOperation(IOperation op)
    {
      this.Op = op;
    }
  }
}