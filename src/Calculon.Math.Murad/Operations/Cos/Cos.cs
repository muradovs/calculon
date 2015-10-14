namespace Calculon.Math.Murad.Operations.Cos
{
  using System;

  public class Cos: UnaryOperation
    {
        public Cos(IExpression param)
            : base(param)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Math.Cos(this.Parameter.Result()));
        }
    }
}
