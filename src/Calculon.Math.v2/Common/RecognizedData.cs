// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecognizedData.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the RecognizedData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Common
{
  using Calculon.Math.V2.Operations;

  /// <summary>
  /// The recognized data.
  /// </summary>
  public class RecognizedData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RecognizedData"/> class.
    /// </summary>
    /// <param name="operation">
    /// The operation.
    /// </param>
    /// <param name="resultString">
    /// The result string.
    /// </param>
    public RecognizedData(IOperation operation, string resultString)
    {
      this.Operation = operation;
      this.ResultString = resultString;
    }

    /// <summary>
    /// Gets the operation.
    /// </summary>
    public IOperation Operation { get; private set; }

    /// <summary>
    /// Gets the result string.
    /// </summary>
    public string ResultString { get; private set; }
  }
}