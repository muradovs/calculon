// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Provides application-specific behavior to supplement the default Application class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.FrontEnd
{
  using System;

  using Calculon.Lib;

  using Windows.ApplicationModel;
  using Windows.ApplicationModel.Activation;
  using Windows.UI.ApplicationSettings;
  using Windows.UI.Xaml;
  using Windows.UI.Xaml.Controls;
  using Windows.UI.Xaml.Controls.Primitives;
  using Windows.UI.Xaml.Media.Animation;

  /// <summary>
  /// The app.
  /// </summary>
  public sealed partial class App : Application
  {
    /// <summary>
    /// The popup.
    /// </summary>
    private Popup popup;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class. 
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
      this.InitializeComponent();
      this.Suspending += this.OnSuspending;
    }

    /// <summary>
    /// Invoked when the application is launched normally by the end user.  Other entry points
    /// will be used when the application is launched to open a specific file, to display
    /// search results, and so forth.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
      var rootFrame = Window.Current.Content as Frame;

      // Do not repeat app initialization when the Window already has content,
      // just ensure that the window is active
      if (rootFrame == null)
      {
        // Create a Frame to act as the navigation context and navigate to the first page
        rootFrame = new Frame();

        if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
        {
          // TODO: Load state from previously suspended application
        }

        // Place the frame in the current Window
        Window.Current.Content = rootFrame;
      }

      if (rootFrame.Content == null)
      {
        // When the navigation stack isn't restored navigate to the first page,
        // configuring the new page by passing required information as a navigation
        // parameter
        if (!rootFrame.Navigate(typeof(MainPage), args.Arguments))
        {
          throw new Exception("Failed to create initial page");
        }
      }

      this.Subscribe();

      // Ensure the current window is active
      Window.Current.Activate();
    }

    /// <summary>
    /// The on activated.
    /// </summary>
    /// <param name="args">
    /// The args.
    /// </param>
    protected override void OnActivated(IActivatedEventArgs args)
    {
      base.OnActivated(args);
    }

    /// <summary>
    /// The on share target activated.
    /// </summary>
    /// <param name="args">
    /// The args.
    /// </param>
    protected override void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
    {
      var frame = new Frame();
      frame.Navigate(typeof(MainPage), args.ShareOperation);
      Window.Current.Content = frame;
      Window.Current.Activate();
    }

    /// <summary>
    /// Invoked when application execution is being suspended.  Application state is saved
    /// without knowing whether the application will be terminated or resumed with the contents
    /// of memory still intact.
    /// </summary>
    /// <param name="sender">The source of the suspend request.</param>
    /// <param name="e">Details about the suspend request.</param>
    private void OnSuspending(object sender, SuspendingEventArgs e)
    {
      var deferral = e.SuspendingOperation.GetDeferral();

      this.UnSubscribe();

      // TODO: Save application state and stop any background activity
      deferral.Complete();
    }

    /// <summary>
    /// The subscribe.
    /// </summary>
    private void Subscribe()
    {
      var currentPane = SettingsPane.GetForCurrentView();
      currentPane.CommandsRequested += this.CurrentPaneCommandsRequested;
    }

    /// <summary>
    /// The un subscribe.
    /// </summary>
    private void UnSubscribe()
    {
      var currentPane = SettingsPane.GetForCurrentView();
      currentPane.CommandsRequested -= this.CurrentPaneCommandsRequested;
    }

    /// <summary>
    /// The current pane_ commands requested.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="args">
    /// The args.
    /// </param>
    private void CurrentPaneCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
    {
      var applicationCommands = args.Request.ApplicationCommands;

      var helpCommand = new SettingsCommand(
        "Help",
        ResourceManager.GetLocalizedString("Help command title"),
        cmd =>
          {
            var page = new HelpPage();
            this.ShowPagePopup(page);
          });
      var aboutCommand = new SettingsCommand(
        "About",
        ResourceManager.GetLocalizedString("About command title"),
        cmd =>
        {
          var page = new AboutPage();
          this.ShowPagePopup(page);
        });

      applicationCommands.Add(helpCommand);
      applicationCommands.Add(aboutCommand);
    }

    /// <summary>
    /// The show page popup.
    /// </summary>
    /// <param name="page">
    /// The page.
    /// </param>
    private void ShowPagePopup(Page page)
    {
      var currentBounds = Window.Current.Bounds;
      const int SettingsWidth = 646;

      this.popup = new Popup();
      this.popup.Closed += this.OnPopupClosed;
      Window.Current.Activated += this.OnWindowActivated;
      this.popup.IsLightDismissEnabled = true;
      this.popup.Width = SettingsWidth;
      this.popup.Height = currentBounds.Height;

      // Add the proper animation for the panel.
      this.popup.ChildTransitions = new TransitionCollection();
      this.popup.ChildTransitions.Add(
        new PaneThemeTransition
          {
            Edge =
              (SettingsPane.Edge == SettingsEdgeLocation.Right)
                ? EdgeTransitionLocation.Right
                : EdgeTransitionLocation.Left
          });

      page.Width = SettingsWidth;
      page.Height = currentBounds.Height;

      // Place the SettingsFlyout inside our Popup window.
      this.popup.Child = page;

      // Let's define the location of our Popup.
      this.popup.SetValue(
        Canvas.LeftProperty, SettingsPane.Edge == SettingsEdgeLocation.Right ? (currentBounds.Width - SettingsWidth) : 0);

      this.popup.SetValue(
        Canvas.LeftProperty, currentBounds.Width - SettingsWidth);

      this.popup.SetValue(Canvas.TopProperty, 0);
      this.popup.IsOpen = true;
    }

    /// <summary>
    /// We use the window's activated event to force closing the Popup since a user maybe interacted with
    /// something that didn't normally trigger an obvious dismiss.
    /// </summary>
    /// <param name="sender">Instance that triggered the event.</param>
    /// <param name="e">Event data describing the conditions that led to the event.</param>
    private void OnWindowActivated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
    {
      if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
      {
        this.popup.IsOpen = false;
      }
    }

    /// <summary>
    /// When the Popup closes we no longer need to monitor activation changes.
    /// </summary>
    /// <param name="sender">Instance that triggered the event.</param>
    /// <param name="e">Event data describing the conditions that led to the event.</param>
    private void OnPopupClosed(object sender, object e)
    {
      Window.Current.Activated -= this.OnWindowActivated;
    }
  }
}
