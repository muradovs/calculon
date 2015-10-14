namespace Calculon.Math.Murad.Operations.Ctan
{
  using System;

  public class Ctan : UnaryOperation
    {
        public Ctan(IExpression param)
            : base(param)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(1 / Math.Tan(this.Parameter.Result()));
        }
    }
}
