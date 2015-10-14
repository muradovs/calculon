// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CalculatorCommand.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the CalculatorCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Model.Commands
{
  using System;
  using System.Windows.Input;

  /// <summary>
  /// The calculator command.
  /// </summary>
  public abstract class CalculatorCommand : ICommand
  {
    /// <summary>
    /// The target.
    /// </summary>
    protected MainViewModel Target;

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculatorCommand"/> class.
    /// </summary>
    /// <param name="target">
    /// The target.
    /// </param>
    protected CalculatorCommand(MainViewModel target)
    {
      this.Target = target;
    }

    /// <summary>
    /// The can execute.
    /// </summary>
    /// <param name="parameter">
    /// The parameter.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public bool CanExecute(object parameter)
    {
      return this.Target != null;
    }

    /// <summary>
    /// The execute.
    /// </summary>
    /// <param name="parameter">
    /// The parameter.
    /// </param>
    public abstract void Execute(object parameter);

    /// <summary>
    /// The can execute changed.
    /// </summary>
    public event EventHandler CanExecuteChanged;
  }
}