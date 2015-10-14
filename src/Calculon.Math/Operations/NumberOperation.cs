// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NumberOperation.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the NumberOperation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.Operations
{
  using System;
  using System.Globalization;

  using Calculon.Math.Expressions;
  using Calculon.Math.Utilities;

  /// <summary>
  /// The number operation.
  /// </summary>
  public sealed class NumberOperation : IOperation
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="NumberOperation"/> class.
    /// </summary>
    /// <param name="ex">
    /// The ex.
    /// </param>
    /// <exception cref="NotSupportedException">
    /// Exception if we have a not supported Expression
    /// </exception>
    public NumberOperation(IExpression ex)
    {
      double op;
      if (ex.StringExpression.IndexOf('+') <= 0 && ex.StringExpression.IndexOf('-') <= 0
          && ex.StringExpression.TryParseAnyway(out op))
      {
        this.Value = op;
      }
      else
      {
        throw new NotSupportedException(ex.StringExpression);
      }
    }

    #region Implementation of IOperation

    /// <summary>
    /// Gets the value.
    /// </summary>
    public double Value { get; private set; }

    #endregion
  }
}