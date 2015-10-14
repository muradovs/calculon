// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOperationRecognizerProvider.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the IOperationRecognizerProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.RecognizerProviders
{
  using System.Collections.Generic;

  using Calculon.Math.V2.Recognizers;

  /// <summary>
  /// The OperationRecognizerProvider interface.
  /// </summary>
  public interface IOperationRecognizerProvider
  {
    /// <summary>
    /// The get recognizers.
    /// </summary>
    /// <returns>
    /// The <see cref="IEnumerable"/>.
    /// </returns>
    IEnumerable<IEnumerable<IOperationRecognizer>> GetRecognizers();
  }
}
