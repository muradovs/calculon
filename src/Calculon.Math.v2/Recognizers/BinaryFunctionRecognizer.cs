// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryFunctionRecognizer.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   The binary function recognizer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Recognizers
{
  using System.Collections.Generic;

  using Calculon.Math.V2.Common;
  using Calculon.Math.V2.OperationProviders;
  using Calculon.Math.V2.Operations;

  /// <summary>
  /// The binary function recognizer.
  /// </summary>
  public class BinaryFunctionRecognizer : BaseRecognizer
  {
    /// <summary>
    /// The _unary operation provider.
    /// </summary>
    private readonly IBinaryOperationProvider operationProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryFunctionRecognizer"/> class.
    /// </summary>
    /// <param name="functionName">
    /// The function name.
    /// </param>
    /// <param name="operationProvider">
    /// The operation provider.
    /// </param>
    public BinaryFunctionRecognizer(string functionName, IBinaryOperationProvider operationProvider)
      : base(new[] { string.Format("[^0-9^A-z]({0}\\([ ]*{{{{exprId=([^}}]*)}}}}[ ]*,[ ]*{{{{exprId=([^}}]*)}}}}[ ]*\\))", functionName) })
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
        if (args.Length > 1)
        {
          var key1 = args[0];
          var key2 = args[1];
          if (operations.ContainsKey(key1) && operations.ContainsKey(key2))
          {
            var op1 = operations[key1];
            var op2 = operations[key2];
            var newOperation = this.operationProvider.GetOperation(op1, op2);
            return this.CreateResult(expression, span, newOperation);
          }
        }
      }

      return null;
    }
  }
}