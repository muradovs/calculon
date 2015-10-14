// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BracketsOperationRecognizer.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the BracketsOperationRecognizer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Recognizers
{
  using System.Collections.Generic;

  using Calculon.Math.V2.Common;
  using Calculon.Math.V2.OperationProviders;
  using Calculon.Math.V2.Operations;

  /// <summary>
  /// The brackets operation recognizer.
  /// </summary>
  public class BracketsOperationRecognizer : BaseRecognizer
  {
    /// <summary>
    /// The operation provider.
    /// </summary>
    private readonly IUnaryOperationProvider operationProvider;

    #region Implementation of IOperationRecognizer

    /// <summary>
    /// Initializes a new instance of the <see cref="BracketsOperationRecognizer"/> class.
    /// </summary>
    /// <param name="operationProvider">
    /// The operation provider.
    /// </param>
    public BracketsOperationRecognizer(IUnaryOperationProvider operationProvider)
      : base(new[] { @"[^0-9^A-z](\([ ]*{{exprId=([^}]*)}}[ ]*\))" })
    {
      this.operationProvider = operationProvider;
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
        var args = this.GetParams(span.Fragment);
        if (args.Length > 0)
        {
          var key = args[0];
          if (operations.ContainsKey(key))
          {
            var newOperation = this.operationProvider.GetOperation(operations[key]);
            return this.CreateResult(expression, span, newOperation);
          }
        }
      }

      return null;
    }

    #endregion
  }
}
