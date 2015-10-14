namespace Calculon.Math.Murad.Operations.Tan
{
  using System;

  public class Tan : UnaryOperation
    {
        public Tan(IExpression param)
            : base(param)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Math.Tan(this.Parameter.Result()));
        }
    }
}
