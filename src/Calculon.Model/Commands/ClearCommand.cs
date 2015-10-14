// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClearCommand.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the ClearCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Model.Commands
{
  /// <summary>
  /// The clear command.
  /// </summary>
  public class ClearCommand : CalculatorCommand
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ClearCommand"/> class.
    /// </summary>
    /// <param name="target">
    /// The target.
    /// </param>
    public ClearCommand(MainViewModel target)
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
      this.Target.CalculatorExpression = string.Empty;
    }
  }
}