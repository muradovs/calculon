// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelLocator.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the ViewModelLocator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Model
{
  /// <summary>
  /// The view model locator.
  /// </summary>
  public class ViewModelLocator
  {
    /// <summary>
    /// The main.
    /// </summary>
    private static MainViewModel main;

    /// <summary>
    /// Initializes a new instance of the ViewModelLocator class.
    /// </summary>
    public ViewModelLocator()
    {
      main = new MainViewModel();
    }

    /// <summary>
    /// Gets the main.
    /// </summary>
    public MainViewModel Main
    {
      get
      {
        return main;
      }
    }
  }
}