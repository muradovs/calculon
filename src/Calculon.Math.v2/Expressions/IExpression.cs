// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IExpression.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the IExpression type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Expressions
{
  /// <summary>
  /// The Expression interface.
  /// </summary>
  public interface IExpression
  {
    /// <summary>
    /// Gets the value.
    /// </summary>
    double Value { get; }

    /// <summary>
    /// Gets a value indicating whether has value.
    /// </summary>
    bool HasValue { get; }

    /// <summary>
    /// Gets the string expression.
    /// </summary>
    string StringExpression { get; }

    /// <summary>
    /// Gets the id.
    /// </summary>
    string Id { get; }
  }
}