// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NumberOperationRecognizer.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the NumberOperationRecognizer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Recognizers
{
  using System.Collections.Generic;

  using Calculon.Math.V2.Common;
  using Calculon.Math.V2.OperationProviders;
  using Calculon.Math.V2.Operations;
  using Calculon.Math.V2.Utilities;

  /// <summary>
  /// The number operation recognizer.
  /// </summary>
  public class NumberOperationRecognizer : BaseRecognizer
  {
    /// <summary>
    /// The operation provider.
    /// </summary>
    private readonly IUnaryOperationProvider operationProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="NumberOperationRecognizer"/> class.
    /// </summary>
    /// <param name="operationProvider">
    /// The operation provider.
    /// </param>
    public NumberOperationRecognizer(IUnaryOperationProvider operationProvider)
      : base(new[] { "[^0-9.^A-z](([0-9.]+))[^0-9.^A-z]" })
    {
      this.operationProvider = operationProvider;
    }

    #region Implementation of IOperationRecognizer

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
        double res;

        if (span.Fragment.TryParseAnyway(out res))
        {
            var num = new NumberOperation(res);
            var newOperation = this.operationProvider.GetOperation(num);
            return this.CreateResult(expression, span, newOperation);
        }
      }

      return null;
    }

    #endregion
  }
}
