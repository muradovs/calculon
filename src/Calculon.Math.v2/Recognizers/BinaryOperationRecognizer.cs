// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryOperationRecognizer.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Класс работает с простыми бинарными операциями (такими как + ,- , *, /)
//   Для работы с классом (для создания простого бинарного рекогнайзера) достаточно переопределить символ операции и возвращаемую операцию.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Recognizers
{
  using System.Collections.Generic;

  using Calculon.Math.V2.Common;
  using Calculon.Math.V2.OperationProviders;
  using Calculon.Math.V2.Operations;

  /// <summary>
  /// Класс работает с простыми бинарными операциями (такими как + ,- , *, /)
  /// Для работы с классом (для создания простого бинарного рекогнайзера) достаточно переопределить символ операции и возвращаемую операцию.
  /// </summary>
  public class BinaryOperationRecognizer : BaseRecognizer
  {
    /// <summary>
    /// The _binary operation provider.
    /// </summary>
    private readonly IBinaryOperationProvider binaryOperationProvider;

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
      : base(new[] { GetPattern("[^0-9^A-z]([ ]*{{{{exprId=([^}}]*)}}}}[ ]*{0}[ ]*{{{{exprId=([^}}]*)}}}}[ ]*)", operationSymbol) })
    {
      this.binaryOperationProvider = binaryOperationProvider;
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
            var newOperation = this.binaryOperationProvider.GetOperation(op1, op2);
            return this.CreateResult(expression, span, newOperation);
          }
        }
      }

      return null;
    }

    /// <summary>
    /// The get pattern.
    /// </summary>
    /// <param name="format">
    /// The format.
    /// </param>
    /// <param name="symbol">
    /// The symbol.
    /// </param>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    private static string GetPattern(string format, string symbol)
    {
      return string.Format(format, symbol.Replace("+", "\\+").Replace("*", "\\*"));
    }
  }
}
