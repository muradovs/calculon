// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstantRecognizer.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the ConstantRecognizer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Recognizers
{
  using System.Collections.Generic;

  using Calculon.Math.V2.Common;
  using Calculon.Math.V2.OperationProviders;
  using Calculon.Math.V2.Operations;

  /// <summary>
  /// The constant recognizer.
  /// </summary>
  public class ConstantRecognizer : BaseRecognizer
  {
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
      : base(new[] { string.Format("[^0-9.^A-z]({0})[^0-9.^A-z]", constString) })
    {
      this.constValue = constValue;
      this.unaryOperationPrvider = unaryOperationPrvider;
    }

    /// <summary>
    /// The recognize.
    /// </summary>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <param name="operations">
    /// The operations.
    /// </param>
    /// <returns>
    /// The <see cref="RecognizedData"/>.
    /// </returns>
    public override RecognizedData Recognize(string expression, IDictionary<string, IOperation> operations)
    {
      var span = this.Index(expression);
      if (span != null)
      {
          var num = new NumberOperation(this.constValue);
          var newOperation = this.unaryOperationPrvider.GetOperation(num);
          return this.CreateResult(expression, span, newOperation);
      }

      return null;
    }
  }
}