// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the MainViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Model
{
  using System.Windows.Input;

  using Calculon.Model.Commands;

  /// <summary>
  /// The main view model.
  /// </summary>
  public class MainViewModel : BaseViewModel
  {
    /// <summary>
    /// The calculator expression.
    /// </summary>
    private string calculatorExpression;

    /// <summary>
    /// The calculator result.
    /// </summary>
    private string calculatorResult;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class.
    /// </summary>
    public MainViewModel()
    {
      this.AddToTextCommand = new AddToTextCommand(this);
      this.RemoveLastCharCommand = new RemoveLastCharCommand(this);
      this.ClearCommand = new ClearCommand(this);
      this.ExecuteExpressionCommand = new ExecuteExpressionCommand(this);
      this.CalculatorResult = " ";
    }

    /// <summary>
    /// Gets or sets the add to text command.
    /// </summary>
    public ICommand AddToTextCommand { get; set; }

    /// <summary>
    /// Gets or sets the remove last char command.
    /// </summary>
    public ICommand RemoveLastCharCommand { get; set; }

    /// <summary>
    /// Gets or sets the clear command.
    /// </summary>
    public ICommand ClearCommand { get; set; }

    /// <summary>
    /// Gets or sets the execute expression command.
    /// </summary>
    public ICommand ExecuteExpressionCommand { get; set; }

    /// <summary>
    /// Gets or sets the calculator expression.
    /// </summary>
    public string CalculatorExpression
    {
      get
      {
        return this.calculatorExpression;
      }

      set
      {
        if (this.calculatorExpression != value)
        {
          this.calculatorExpression = value;
          this.OnPropertyChanged();
        }
      }
    }

    /// <summary>
    /// Gets or sets the calculator result.
    /// </summary>
    public string CalculatorResult
    {
      get
      {
        return this.calculatorResult;
      }

      set
      {
        if (this.calculatorResult != value)
        {
          this.calculatorResult = value;
          this.OnPropertyChanged();
        }
      }
    }
  }
}