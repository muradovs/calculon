// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddToTextCommand.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the AddToTextCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Model.Commands
{
  /// <summary>
  /// The add to text command.
  /// </summary>
  public class AddToTextCommand : CalculatorCommand
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="AddToTextCommand"/> class.
    /// </summary>
    /// <param name="target">
    /// The target.
    /// </param>
    public AddToTextCommand(MainViewModel target)
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
      var str = parameter as string;
      if (!string.IsNullOrEmpty(str))
      {
        this.Target.CalculatorExpression += str;
      }
    }
  }
}