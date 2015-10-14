// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationExecutor.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Класс занимается поиском подходящей операции для выражения.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.Executors
{
  using System.Collections.Generic;

  using Calculon.Math.Operations;
  using Calculon.Math.RecognizerProviders;

  /// <summary>
  /// Класс занимается поиском подходящей операции для выражения.
  /// </summary>
  public class OperationExecutor : IOperationExecutor
  {
    /// <summary>
    /// The max expressions.
    /// </summary>
    private const int MaxExpressions = 10000;

    /// <summary>
    ///  Это я ввел только для ускорения времени расчета, так как алгоритм перебирает много вариантов решения выражения, он
    /// работет долго. Кеширование результатов ускоряет его в разы - это подходит для небольших выражений, но для 
    /// больших выражений надо будет уже оптимизировать алгоритм.
    /// </summary>
    private static readonly Dictionary<string, IOperation> Results = new Dictionary<string, IOperation>();

    /// <summary>
    /// The operation recognizer provider.
    /// </summary>
    private readonly IOperationRecognizerProvider operationRecognizerProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="OperationExecutor"/> class.
    /// </summary>
    /// <param name="operationRecognizerProvider">
    /// The operation recognizer provider.
    /// </param>
    public OperationExecutor(IOperationRecognizerProvider operationRecognizerProvider)
    {
      this.operationRecognizerProvider = operationRecognizerProvider;
    }

    #region Implementation of IOperationExecutor

    /// <summary>
    /// The get operation.
    /// </summary>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <returns>
    /// The <see cref="IOperation"/>.
    /// </returns>
    public IOperation GetOperation(string expression)
    {
      if (string.IsNullOrEmpty(expression))
      {
        return null;
      }

      if (Results.ContainsKey(expression))
      {
        return Results[expression];
      }

      // тут находятся рекогнайзеры операций в обратном порядке приоритета. 
      var recognizerLists = this.operationRecognizerProvider.GetRecognizers();

      // Тут происходит поиск подходящей операции. Если поиск завершится неудачей, 
      // значит выражение разобрать невозможно и вернется null
      foreach (var recognizerList in recognizerLists)
      {
        var minIndex = -1;
        IOperation result = null;

        foreach (var operationRecognizer in recognizerList)
        {
          var index = operationRecognizer.Index(expression, new OperationExecutor(this.operationRecognizerProvider));
          if (index == -1)
          {
            continue;
          }

          if (minIndex == -1 || minIndex < index)
          {
            minIndex = index;
            result = operationRecognizer.Recognize(expression, new OperationExecutor(this.operationRecognizerProvider));
          }
        }

        if (minIndex != -1)
        {
          // просто кешируем
          if (Results.Count > MaxExpressions)
          {
            Results.Clear();
          }

          Results.Add(expression, result);

          return result;
        }
      }

      // просто кешируем
      if (Results.Count > MaxExpressions)
      {
        Results.Clear();
      }

      Results.Add(expression, null);

      return null;
    }

    #endregion
  }
}
