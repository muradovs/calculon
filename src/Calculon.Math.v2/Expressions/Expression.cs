// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Expression.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the Expression type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Expressions
{
  using System;

  using Calculon.Math.V2.Executors;
  using Calculon.Math.V2.Operations;

  /// <summary>
  /// The expression.
  /// </summary>
  public sealed class Expression : IExpression
  {
    /// <summary>
    /// The expression.
    /// </summary>
    private readonly string expression;

    /// <summary>
    /// The operation executor.
    /// </summary>
    private readonly IOperationExecutor operationExecutor;

    /// <summary>
    /// The operation.
    /// </summary>
    private IOperation operation;

    /// <summary>
    /// The create.
    /// </summary>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <param name="operationExecutor">
    /// The operation executor.
    /// </param>
    /// <returns>
    /// The <see cref="Expression"/>.
    /// </returns>
    public static Expression Create(string expression, IOperationExecutor operationExecutor)
    {
      expression = expression.Replace(" ", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty);
      return new Expression(expression, operationExecutor);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Expression"/> class.
    /// </summary>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <param name="operationExecutor">
    /// The operation executor.
    /// </param>
    private Expression(string expression, IOperationExecutor operationExecutor)
    {
      this.expression = expression;
      this.operationExecutor = operationExecutor;
      this.Id = Guid.NewGuid().ToString();
    }

    #region Implementation of IExpression

    /// <summary>
    /// Gets the string expression.
    /// </summary>
    public string StringExpression
    {
      get { return this.expression; }
    }

    public string Id { get; private set; }

    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <exception cref="NotSupportedException">
    /// </exception>
    public double Value
    {
      get
      {
        if (this.operation == null) this.operation = this.operationExecutor.GetOperation(this.expression);
        if (this.operation == null) throw new NotSupportedException(this.expression);
        return this.operation.Value;
      }
    }

    /// <summary>
    /// Gets a value indicating whether has value.
    /// </summary>
    public bool HasValue
    {
      get
      {
        if (this.operation == null) this.operation = this.operationExecutor.GetOperation(this.expression);
        return this.operation != null;
      }
    }

    #endregion
  }
}