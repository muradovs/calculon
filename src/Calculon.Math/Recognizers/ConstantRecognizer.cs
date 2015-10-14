// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstantRecognizer.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the ConstantRecognizer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.Recognizers
{
  using System;
  using System.Globalization;

  using Calculon.Math.Executors;
  using Calculon.Math.Expressions;
  using Calculon.Math.OperationProviders;
  using Calculon.Math.Operations;

  /// <summary>
  /// The constant recognizer.
  /// </summary>
  public class ConstantRecognizer : IOperationRecognizer
  {
    /// <summary>
    /// The const string.
    /// </summary>
    private readonly string constString;

    /// <summary>
    /// The const value.
    /// </summary>
    private readonly double constValue;

    /// <summary>
    /// The unary operation prvider.
    /// </summary>
    private readonly IUnaryOperationProvider unaryOperationPrvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConstantRecognizer"/> class.
    /// </summary>
    /// <param name="constString">
    /// The const string.
    /// </param>
    /// <param name="constValue">
    /// The const value.
    /// </param>
    /// <param name="unaryOperationPrvider">
    /// The unary operation prvider.
    /// </param>
    public ConstantRecognizer(string constString, double constValue, IUnaryOperationProvider unaryOperationPrvider)
    {
      this.constString = constString;
      this.constValue = constValue;
      this.unaryOperationPrvider = unaryOperationPrvider;
    }

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
      if (expression == this.constString)
      {
        return this.unaryOperationPrvider.GetOperation(Expression.Create(this.constValue.ToString(CultureInfo.InvariantCulture), operationExecutor));
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
      return expression == this.constString ? 0 : -1;
    }
  }
}