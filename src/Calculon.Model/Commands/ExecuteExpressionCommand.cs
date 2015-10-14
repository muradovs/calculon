// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExecuteExpressionCommand.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the ExecuteExpressionCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Model.Commands
{
  using System;
  using System.Globalization;
  using System.Linq;
  using System.Text;

  using Calculon.Lib;
  using Calculon.Math.Murad;

  using Calculon.Math.Executors;
  using Calculon.Math.Expressions;
  using Calculon.Math.RecognizerProviders;

  /// <summary>
  /// The execute expression command.
  /// </summary>
  public class ExecuteExpressionCommand : CalculatorCommand
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ExecuteExpressionCommand"/> class.
    /// </summary>
    /// <param name="target">
    /// The target.
    /// </param>
    public ExecuteExpressionCommand(MainViewModel target)
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
      var targetComand = string.IsNullOrEmpty(this.Target.CalculatorExpression) ? "0" : this.Target.CalculatorExpression;
      var commands = targetComand.Split(new[] { ';' }).Where(x=>!string.IsNullOrEmpty(x)).ToArray();
      var results = new string[commands.Length];
      for (var i = 0; i < commands.Length; i++)
      {
        results[i] = ExecuteCommand(commands[i]);
      }

      var result = new StringBuilder();

      foreach (var res in results)
      {
        result.AppendLine(res);
      }

      this.Target.CalculatorResult = result.ToString();

      /*try
      {
        var operationExecutor = new OperationExecutor(new OperationRecognizerProvider());
        var ex = Expression.Create(string.IsNullOrEmpty(this.Target.CalculatorExpression) ? "0" : this.Target.CalculatorExpression, operationExecutor);
        this.Target.CalculatorResult = Math.Round(ex.Value, 10).ToString(CultureInfo.InvariantCulture);
      }
      catch (Exception)
      {
        this.Target.CalculatorResult = string.Format(ResourceManager.GetLocalizedString("Error_CantResolve"), this.Target.CalculatorExpression);
      }*/
    }

    /// <summary>
    /// The execute command.
    /// </summary>
    /// <param name="command">
    /// The command.
    /// </param>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    private static string ExecuteCommand(string command)
    {
      string result;
      try
      {
        //var expression = ExpressionParser.Parse(string.IsNullOrEmpty(command) ? "0" : command);
        //result = Math.Round(expression.Result(), 10).ToString(CultureInfo.InvariantCulture);

          var operationExecutor = new OperationExecutor(new OperationRecognizerProvider());
          var ex =
            Expression.Create(
              string.IsNullOrEmpty(command) ? "0" : command,
              operationExecutor);
          result = Math.Round(ex.Value, 10).ToString(CultureInfo.InvariantCulture);
      }
      catch (Exception e)
      {
        result = string.Format(
          ResourceManager.GetLocalizedString("Error_CantResolve"), e.Message);
      }

      return result;
    }
  }
}