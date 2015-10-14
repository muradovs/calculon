namespace Calculon.Math.Murad.Operations.Atan
{
  using System;

  public sealed class Atan : UnaryOperation
    {
        public Atan(IExpression param)
            : base(param)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Math.Atan(this.Parameter.Result()));
        }
    }
}
