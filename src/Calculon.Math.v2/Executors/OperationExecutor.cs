// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationExecutor.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Класс занимается поиском подходящей операции для выражения.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Executors
{
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;

  using Calculon.Math.V2.Operations;
  using Calculon.Math.V2.RecognizerProviders;

  /// <summary>
  /// Класс занимается поиском подходящей операции для выражения.
  /// </summary>
  public class OperationExecutor : IOperationExecutor
  {
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

      var providers = this.operationRecognizerProvider.GetRecognizers();

      var dictionary = new Dictionary<string, IOperation>();

      var prevExpression = " " + expression + " ";

      IOperation lastOperation = null;

      while (true)
      {
        var startExpression = prevExpression;
       
        foreach (var provider in providers)
        {
          var result =
            provider.ToList()
                    .Select(x => new { ind = x.Index(prevExpression), prov = x })
                    .Where(x => x.ind != null)
                    .OrderBy(x => x.ind.StartIndex).Select(x=>x.prov.Recognize(prevExpression, dictionary))
                    .FirstOrDefault();

          if (result != null)
          {
            Debug.WriteLine("change from {0} to {1} with {2}", prevExpression, result.ResultString, result.Operation);
            prevExpression = result.ResultString;
            dictionary.Add(result.Operation.Id, result.Operation);
            lastOperation = result.Operation;

            break;
          }
        }

        if (startExpression == prevExpression)
        {
          break;
        }
      }

      return lastOperation;
    }

    #endregion
  }
}
