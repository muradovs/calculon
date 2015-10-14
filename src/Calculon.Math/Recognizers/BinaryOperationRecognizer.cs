// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryOperationRecognizer.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Класс работает с простыми бинарными операциями (такими как + ,- , *, /)
//   Для работы с классом (для создания простого бинарного рекогнайзера) достаточно переопределить символ операции и возвращаемую операцию.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.Recognizers
{
  using System;

  using Calculon.Math.Executors;
  using Calculon.Math.Expressions;
  using Calculon.Math.OperationProviders;
  using Calculon.Math.Operations;

  /// <summary>
  /// Класс работает с простыми бинарными операциями (такими как + ,- , *, /)
  /// Для работы с классом (для создания простого бинарного рекогнайзера) достаточно переопределить символ операции и возвращаемую операцию.
  /// </summary>
  public class BinaryOperationRecognizer : IOperationRecognizer
  {
    /// <summary>
    /// The operation symbol.
    /// </summary>
    private readonly string operationSymbol;

    /// <summary>
    /// The _binary operation provider.
    /// </summary>
    private readonly IBinaryOperationProvider binaryOperationProvider;

    /// <summary>
    /// The ex 1.
    /// </summary>
    private Expression ex1;

    /// <summary>
    /// The ex 2.
    /// </summary>
    private Expression ex2;

    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryOperationRecognizer"/> class.
    /// </summary>
    /// <param name="operationSymbol">
    /// The operation symbol.
    /// </param>
    /// <param name="binaryOperationProvider">
    /// The binary operation provider.
    /// </param>
    public BinaryOperationRecognizer(string operationSymbol, IBinaryOperationProvider binaryOperationProvider)
    {
      this.operationSymbol = operationSymbol;
      this.binaryOperationProvider = binaryOperationProvider;
    }

    #region Implementation of IOperationRecognizer

    /// <summary>
    /// The recognize.
    /// </summary>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <param name="operationExecutor">
    /// The operation executor.
    /// </param>
    /// <returns>
    /// The <see cref="IOperation"/>.
    /// </returns>
    /// <exception cref="NotSupportedException">
    /// Not Supported Exception
    /// </exception>
    public IOperation Recognize(string expression, IOperationExecutor operationExecutor)
    {
      var si = this.Index(expression, operationExecutor);

      if (si >= 0)
      {
        var sop1 = expression.Substring(0, si);
        var sop2 = expression.Substring(si + 1, expression.Length - si - 1);

        var check = this.CheckOperation(sop1, sop2, operationExecutor);
        if (check)
        {
          return this.binaryOperationProvider.GetOperation(this.ex1, this.ex2);
        }
      }

      throw new NotSupportedException(expression);
    }

    /// <summary>
    /// The index.
    /// </summary>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <param name="operationExecutor">
    /// The operation executor.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public int Index(string expression, IOperationExecutor operationExecutor)
    {
      var maxIndex = -1;
      for (var i = 0; i < expression.Length; i++)
      {
        var ind = expression.IndexOf(this.operationSymbol, i, StringComparison.Ordinal);
        if (ind > maxIndex && (ind + this.operationSymbol.Length) <= (expression.Length - 1))
        {
          var sop1 = expression.Substring(0, ind);
          var sop2 = expression.Substring(ind + this.operationSymbol.Length, expression.Length - ind - this.operationSymbol.Length);

          if (this.CheckOperation(sop1, sop2, operationExecutor))
          {
            maxIndex = ind;
          }
        }
      }

      return maxIndex;
    }

    /// <summary>
    /// The check operation.
    /// </summary>
    /// <param name="op1">
    /// The op 1.
    /// </param>
    /// <param name="op2">
    /// The op 2.
    /// </param>
    /// <param name="operationExecutor">
    /// The operation executor.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    private bool CheckOperation(string op1, string op2, IOperationExecutor operationExecutor)
    {
      this.ex1 = Expression.Create(op1, operationExecutor);
      if (!this.ex1.HasValue)
      {
        return false;
      }

      this.ex2 = Expression.Create(op2, operationExecutor);
      return this.ex2.HasValue;
    }

    #endregion
  }
}
