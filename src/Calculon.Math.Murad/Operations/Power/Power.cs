namespace Calculon.Math.Murad.Operations.Power
{
  using System;

  public class Power: BinaryOperation
    {
        public Power(IExpression param1, IExpression param2)
            : base(param1, param2)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Math.Pow(this.Parameter1.Result(), this.Parameter2.Result()));
        }
    }
}
