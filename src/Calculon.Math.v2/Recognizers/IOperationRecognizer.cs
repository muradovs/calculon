// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOperationRecognizer.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the IOperationRecognizer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Recognizers
{
  using System.Collections.Generic;

  using Calculon.Math.V2.Common;
  using Calculon.Math.V2.Operations;

  /// <summary>
  /// The OperationRecognizer interface.
  /// </summary>
  public interface IOperationRecognizer
  {
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
    RecognizedData Recognize(string expression, IDictionary<string, IOperation> operations);

    /// <summary>
    /// The index.
    /// </summary>
    /// <param name="expression">
    /// The expression.
    /// </param>
    /// <returns>
    /// The <see cref="Span"/>.
    /// </returns>
    Span Index(string expression);
  }
}
