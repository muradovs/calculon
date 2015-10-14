// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOperationRecognizerProvider.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the IOperationRecognizerProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.RecognizerProviders
{
  using System.Collections.Generic;

  using Calculon.Math.Recognizers;

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
