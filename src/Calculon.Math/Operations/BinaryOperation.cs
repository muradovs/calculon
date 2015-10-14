// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryOperation.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the BinaryOperation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.Operations
{
  using Calculon.Math.Expressions;

  /// <summary>
  /// The binary operation.
  /// </summary>
  public abstract class BinaryOperation : IOperation
  {
    /// <summary>
    /// The ex 1.
    /// </summary>
    protected readonly IExpression Ex1;

    /// <summary>
    /// The ex 2.
    /// </summary>
    protected readonly IExpression Ex2;

    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryOperation"/> class.
    /// </summary>
    /// <param name="exp1">
    /// The exp 1.
    /// </param>
    /// <param name="exp2">
    /// The exp 2.
    /// </param>
    protected BinaryOperation(IExpression exp1, IExpression exp2)
    {
      this.Ex1 = exp1;
      this.Ex2 = exp2;
    }

    #region Implementation of IOperation

    /// <summary>
    /// Gets the value.
    /// </summary>
    public abstract double Value { get; }

    #endregion
  }
}