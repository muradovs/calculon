namespace Calculon.Math.Murad.Operations.Sqrt
{
  using System;

  public class Sqrt: UnaryOperation
    {
        public Sqrt(IExpression param)
            : base(param)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Math.Sqrt(this.Parameter.Result()));
        }
    }
}
