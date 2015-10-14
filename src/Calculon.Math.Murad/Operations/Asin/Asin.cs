namespace Calculon.Math.Murad.Operations.Asin
{
  using System;

  public sealed class Asin : UnaryOperation
    {
        public Asin(IExpression param)
            : base(param)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Math.Asin(this.Parameter.Result()));
        }
    }
}
