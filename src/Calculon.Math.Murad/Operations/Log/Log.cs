namespace Calculon.Math.Murad.Operations.Log
{
  using System;

  public class Log: BinaryOperation
    {
        public Log(IExpression param1, IExpression param2)
            : base(param1, param2)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Math.Log(this.Parameter1.Result(), this.Parameter2.Result()));
        }
    }
}
