// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnaryFunctionRecognizer.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the UnaryFunctionRecognizer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Recognizers
{
  using System.Collections.Generic;

  using Calculon.Math.V2.Common;
  using Calculon.Math.V2.OperationProviders;
  using Calculon.Math.V2.Operations;

  /// <summary>
  /// The unary function recognizer.
  /// </summary>
  public class UnaryFunctionRecognizer : BaseRecognizer
  {
    /// <summary>
    /// The _unary operation provider.
    /// </summary>
    private readonly IUnaryOperationProvider unaryOperationProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnaryFunctionRecognizer"/> class.
    /// </summary>
    /// <param name="functionName">
    /// The function name.
    /// </param>
    /// <param name="unaryOperationProvider">
    /// The unary operation provider.
    /// </param>
    public UnaryFunctionRecognizer(string functionName, IUnaryOperationProvider unaryOperationProvider)
      : base(new[] { string.Format("[^0-9^A-z]({0}\\([ ]*{{{{exprId=([^}}]*)}}}}[ ]*\\))", functionName) })
    {
      this.unaryOperationProvider = unaryOperationProvider;
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
            var newOperation = this.unaryOperationProvider.GetOperation(operations[key]);
            return this.CreateResult(expression, span, newOperation);
          }
        }
      }

      return null;
    }
  }
}