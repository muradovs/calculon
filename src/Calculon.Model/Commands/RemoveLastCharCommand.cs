// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveLastCharCommand.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the RemoveLastCharCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Model.Commands
{
  using Calculon.Model;

  /// <summary>
  /// The remove last char command.
  /// </summary>
  public class RemoveLastCharCommand : CalculatorCommand
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RemoveLastCharCommand"/> class.
    /// </summary>
    /// <param name="target">
    /// The target.
    /// </param>
    public RemoveLastCharCommand(MainViewModel target)
      : base(target)
    {
    }

    /// <summary>
    /// The execute.
    /// </summary>
    /// <param name="parameter">
    /// The parameter.
    /// </param>
    public override void Execute(object parameter)
    {
      if (!string.IsNullOrEmpty(this.Target.CalculatorExpression))
      {
        this.Target.CalculatorExpression = this.Target.CalculatorExpression.Substring(
          0, this.Target.CalculatorExpression.Length - 1);
      }
    }
  }
}