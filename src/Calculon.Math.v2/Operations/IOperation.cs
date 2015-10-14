// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOperation.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the IOperation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Operations
{
  /// <summary>
  /// The Operation interface.
  /// </summary>
  public interface IOperation
  {
    /// <summary>
    /// Gets the value.
    /// </summary>
    double Value { get; }

    /// <summary>
    /// Gets the id.
    /// </summary>
    string Id { get; }
  }
}