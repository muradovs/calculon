// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Span.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the Span type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Math.V2.Common
{
  /// <summary>
  /// The span.
  /// </summary>
  public class Span
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Span"/> class.
    /// </summary>
    /// <param name="startIndex">
    /// The start index.
    /// </param>
    /// <param name="length">
    /// The length.
    /// </param>
    /// <param name="fragment">
    /// The fragment.
    /// </param>
    public Span(int startIndex, int length, string fragment)
    {
      this.StartIndex = startIndex;
      this.Length = length;
      this.Fragment = fragment;
    }

    /// <summary>
    /// Gets the start index.
    /// </summary>
    public int StartIndex { get; private set; }

    /// <summary>
    /// Gets the length.
    /// </summary>
    public int Length { get; private set; }

    /// <summary>
    /// Gets the fragment.
    /// </summary>
    public string Fragment { get; private set; }
  }
}