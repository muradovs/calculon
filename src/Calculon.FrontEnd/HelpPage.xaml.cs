// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AboutPage.xaml.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Calculon.FrontEnd
{
  using Calculon.Lib;

  using Windows.UI.ApplicationSettings;
  using Windows.UI.Xaml;
  using Windows.UI.Xaml.Controls.Primitives;
  using Windows.UI.Xaml.Media.Animation;

  /// <summary>
  /// A basic page that provides characteristics common to most applications.
  /// </summary>
  public sealed partial class HelpPage
  {
    /// <summary>
    /// The guidelines recommend using 100px offset for the content animation.
    /// </summary>
    private const int ContentAnimationOffset = 100;

    /// <summary>
    /// Initializes a new instance of the <see cref="HelpPage"/> class.
    /// </summary>
    public HelpPage()
    {
      this.InitializeComponent();
      tbTitle.Text = ResourceManager.GetLocalizedString("Help command title");
      taContent.Text = ResourceManager.GetLocalizedString("HelpText");
      FlyoutContent.Transitions = new TransitionCollection
                                    {
                                      new EntranceThemeTransition
                                        {
                                          FromHorizontalOffset =
                                            (SettingsPane.Edge
                                             == SettingsEdgeLocation
                                                  .Right)
                                              ? ContentAnimationOffset
                                              : (ContentAnimationOffset
                                                 * -1)
                                        }
                                    };
    }

    /// <summary>
    /// The my settings back clicked.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void MySettingsBackClicked(object sender, RoutedEventArgs e)
    {
      // First close our Flyout.
      var parent = this.Parent as Popup;
      if (parent != null)
      {
        parent.IsOpen = false;
      }

      // If the app is not snapped, then the back button shows the Settings pane again.
      if (Windows.UI.ViewManagement.ApplicationView.Value != Windows.UI.ViewManagement.ApplicationViewState.Snapped)
      {
        SettingsPane.Show();
      }
    }
  }
}
