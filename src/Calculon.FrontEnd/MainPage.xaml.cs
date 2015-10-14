// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPage.xaml.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   An empty page that can be used on its own or navigated to within a Frame.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculon.FrontEnd
{
  using System;

  using Calculon.Lib;
  using Calculon.Model;

  using Windows.ApplicationModel.DataTransfer;
  using Windows.ApplicationModel.DataTransfer.ShareTarget;
  using Windows.UI.Xaml;
  using Windows.UI.Xaml.Navigation;

  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage
  {
    /// <summary>
    /// The model.
    /// </summary>
    private readonly MainViewModel model;

    /// <summary>
    /// The old expression.
    /// </summary>
    private string oldExpression = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainPage"/> class.
    /// </summary>
    public MainPage()
    {
      this.InitializeComponent();

      this.model = new MainViewModel();
      this.DataContext = this.model;

      tbExpression.Focus(FocusState.Keyboard);
    }

    /// <summary>
    /// Invoked when this page is about to be displayed in a Frame.
    /// </summary>
    /// <param name="e">Event data that describes how this page was reached.  The Parameter
    /// property is typically used to configure the page.</param>
    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);
      if (e.Parameter is ShareOperation)
      {
        var shareOperation = e.Parameter as ShareOperation;
        if (shareOperation.Data.Contains(StandardDataFormats.Text))
        {
          var text = await shareOperation.Data.GetTextAsync();
          tbExpression.Text = text.Trim('\n', '\r', ' ');
          this.EnsureProcessExpression();
        }
        else if (shareOperation.Data.Contains(StandardDataFormats.Html))
        {
          var text = await shareOperation.Data.GetHtmlFormatAsync();
          text = HtmlHelper.RemoveTags(text);
          tbExpression.Text = text.Trim('\n', '\r', ' ');
          this.EnsureProcessExpression();
        }
      }

      var currentManager = DataTransferManager.GetForCurrentView();
      currentManager.DataRequested += this.CurrentManagerDataRequested;
    }

    /// <summary>
    /// The on navigated from.
    /// </summary>
    /// <param name="e">
    /// The e.
    /// </param>
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      var currentManager = DataTransferManager.GetForCurrentView();
      currentManager.DataRequested -= this.CurrentManagerDataRequested;
    }

    /// <summary>
    /// The current manager_ data requested.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="args">
    /// The args.
    /// </param>
    private void CurrentManagerDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
    {
      if (!string.IsNullOrEmpty(tbExpression.Text))
      {
        var title = ResourceManager.GetLocalizedString("Sharing_Title");
        var description = ResourceManager.GetLocalizedString("Sharing_Description");

        if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(description))
        {
          var defferal = args.Request.GetDeferral();
          args.Request.Data.Properties.Title = title;
          args.Request.Data.Properties.Description = description;
          args.Request.Data.SetText(string.Format("{0}={1}", this.model.CalculatorExpression, this.model.CalculatorResult));
          defferal.Complete();
        }
      }
    }

    /// <summary>
    /// The button base_ on click.
    /// </summary>
    /// <param name="sender">
    /// The sender.
    /// </param>
    /// <param name="e">
    /// The e.
    /// </param>
    private void EvaluateClick(object sender, RoutedEventArgs e)
    {
      this.EnsureProcessExpression();
    }

    /// <summary>
    /// The process expression.
    /// </summary>
    private void ProcessExpression()
    {
      this.model.ExecuteExpressionCommand.Execute(this.model);
      tbExpression.Focus(FocusState.Keyboard);
    }

    /// <summary>
    /// The ensure process expression.
    /// </summary>
    private void EnsureProcessExpression()
    {
      var currentExpression = tbExpression.Text;
      var newExpression = currentExpression.Trim('\n', '\r', ' '); 
      if (string.CompareOrdinal(this.oldExpression, newExpression) != 0)
      {
        this.oldExpression = newExpression;
        this.model.CalculatorExpression = newExpression;
        this.ProcessExpression();
        tbExpression.Text = currentExpression;
        tbResult.Text = this.model.CalculatorResult;
      }
    }
  }
}
