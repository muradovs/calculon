// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationRecognizerProvider.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the OperationRecognizerProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.RecognizerProviders
{
  using System.Collections.Generic;
  using Calculon.Math.OperationProviders;
  using Calculon.Math.Recognizers;

  /// <summary>
  /// The operation recognizer provider.
  /// </summary>
  public class OperationRecognizerProvider : IOperationRecognizerProvider
  {
    #region Implementation of IOperationRecognizerProvider

    /// <summary>
    /// тут находятся рекогнайзеры операций в обратном порядке приоритета. 
    /// </summary>
    /// <returns>Массив массивов рекогнайзеров, [Массив для разных приоритетов операций[Массив для одинаковых приоритетов операций]] например [[+;-][*;/][sin;cos]]</returns>
    public IEnumerable<IEnumerable<IOperationRecognizer>> GetRecognizers()
    {
      return new List<IEnumerable<IOperationRecognizer>>
               {
                 new List<IOperationRecognizer>
                   {
                     new BinaryOperationRecognizer
                       (
                       "+",
                       new LambdaBinaryOperationProvider
                       ((x, y) => x + y)),
                     new BinaryOperationRecognizer
                       (
                       "-",
                       new LambdaBinaryOperationProvider
                       ((x, y) => x - y))
                   },
                 new List<IOperationRecognizer>
                   {
                     new BinaryOperationRecognizer
                       (
                       "*",
                       new LambdaBinaryOperationProvider
                       ((x, y) => x * y)),
                       new BinaryOperationRecognizer
                       (
                       "•",
                       new LambdaBinaryOperationProvider
                       ((x, y) => x * y)),
                     new BinaryOperationRecognizer
                       (
                       "/",
                       new LambdaBinaryOperationProvider
                       ((x, y) => x / y)),
                       new BinaryOperationRecognizer
                       (
                       ":",
                       new LambdaBinaryOperationProvider
                       ((x, y) => x / y)),
                   },
                 new List<IOperationRecognizer>
                   {
                     new BinaryOperationRecognizer
                       (
                       "^",
                       new LambdaBinaryOperationProvider
                       (System.Math.Pow)),
                   },
                   new List<IOperationRecognizer>
                   {
                     new BracketsOperationRecognizer
                       (
                       new LambdaUnaryOperationProvider
                       (x => x)),
                     //new AbsoluteBracketsOperationRecognizer
                     //  (
                     //  new LambdaUnaryOperationProvider
                     //  (System.Math.Abs))
                   },
                 new List<IOperationRecognizer>
                   {
                     new UnaryFunctionRecognizer(
                       "sin",
                       new LambdaUnaryOperationProvider
                       (System.Math.Sin)),
                     new UnaryFunctionRecognizer(
                       "cos",
                       new LambdaUnaryOperationProvider
                       (System.Math.Cos)),
                     new UnaryFunctionRecognizer(
                       "tan",
                       new LambdaUnaryOperationProvider
                       (System.Math.Tan)),
                     new UnaryFunctionRecognizer(
                       "ctan",
                       new LambdaUnaryOperationProvider
                       (
                       x =>
                       1 / System.Math.Tan(x))),
                     new UnaryFunctionRecognizer(
                       "asin",
                       new LambdaUnaryOperationProvider
                       (System.Math.Asin)),
                     new UnaryFunctionRecognizer(
                       "acos",
                       new LambdaUnaryOperationProvider
                       (System.Math.Acos)),
                     new UnaryFunctionRecognizer(
                       "atan",
                       new LambdaUnaryOperationProvider
                       (System.Math.Atan)),
                     new UnaryFunctionRecognizer(
                       "actan",
                       new LambdaUnaryOperationProvider
                       (
                       x =>
                       (System.Math.PI * 0.5)
                       - System.Math.Atan(x))),
                     new UnaryFunctionRecognizer(
                       "abs",
                       new LambdaUnaryOperationProvider
                       (System.Math.Abs)),
                     new UnaryFunctionRecognizer(
                       "sqrt",
                       new LambdaUnaryOperationProvider
                       (System.Math.Sqrt)),
                        new UnaryFunctionRecognizer(
                       "lg",
                       new LambdaUnaryOperationProvider
                       (System.Math.Log10)),
                        new UnaryFunctionRecognizer(
                       "ln",
                       new LambdaUnaryOperationProvider
                       (System.Math.Log)),
                   },
                  new List<IOperationRecognizer>
                   {
                     new BinaryFunctionRecognizer(
                       "log",
                       new LambdaBinaryOperationProvider
                       ((x, y) => { return System.Math.Log(x, y); })),
                        new BinaryFunctionRecognizer(
                       "max",
                       new LambdaBinaryOperationProvider
                       ((x, y) => { return System.Math.Max(x, y); })),
                        new BinaryFunctionRecognizer(
                       "min",
                       new LambdaBinaryOperationProvider
                       ((x, y) => { return System.Math.Min(x, y); })),
                   },
                 new List<IOperationRecognizer>
                   {
                     new ConstantRecognizer(
                       "pi",
                       System.Math.PI,
                       new NumberOperationProvider
                       ()),
                     new ConstantRecognizer(
                       "e",
                       System.Math.E,
                       new NumberOperationProvider
                       ()),
                       new ConstantRecognizer(
                       "½",
                       0.5,
                       new NumberOperationProvider
                       ())
                   },
                 new List<IOperationRecognizer>
                   {
                     new NumberOperationRecognizer
                       (
                       new NumberOperationProvider
                       ())
                   },
               };
    }

    #endregion
  }
}
