// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseOperation.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the BaseOperation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Operations
{
  using System;

  /// <summary>
  /// The base operation.
  /// </summary>
  public abstract class BaseOperation : IOperation
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseOperation"/> class.
    /// </summary>
    protected BaseOperation()
    {
      this.Id = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public abstract double Value { get; protected set; }

    /// <summary>
    /// Gets the id.
    /// </summary>
    public string Id { get; private set; }
  }
}