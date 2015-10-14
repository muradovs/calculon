// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NumberOperation.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the NumberOperation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Operations
{
  /// <summary>
  /// The number operation.
  /// </summary>
  public sealed class NumberOperation : BaseOperation
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="NumberOperation"/> class.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    public NumberOperation(double value)
    {
      this.Value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NumberOperation"/> class.
    /// </summary>
    /// <param name="op">
    /// The op.
    /// </param>
    public NumberOperation(IOperation op)
    {
      this.Value = op.Value;
    }

    #region Implementation of IOperation

    /// <summary>
    /// Gets the value.
    /// </summary>
    public override double Value { get; protected set; }

    #endregion
  }
}