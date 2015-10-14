namespace Calculon.Math.Murad.Operations.Lg
{
  using System;

  public sealed class Lg : UnaryOperation
    {
        public Lg(IExpression param)
            : base(param)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Math.Log10(this.Parameter.Result()));
        }
    }
}
