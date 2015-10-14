// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnaryOperation.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the UnaryOperation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.Operations
{
  using Calculon.Math.Expressions;

  /// <summary>
  /// The unary operation.
  /// </summary>
  public abstract class UnaryOperation : IOperation
  {
    /// <summary>
    /// The ex.
    /// </summary>
    protected readonly IExpression Ex;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnaryOperation"/> class.
    /// </summary>
    /// <param name="ex">
    /// The ex.
    /// </param>
    protected UnaryOperation(IExpression ex)
    {
      Ex = ex;
    }

    #region Implementation of IOperation

    /// <summary>
    /// Gets the value.
    /// </summary>
    public abstract double Value { get; }

    #endregion
  }
}