namespace Calculon.Math.Murad.Operations.Acos
{
  using System;

  public sealed class Acos : UnaryOperation
    {
        public Acos(IExpression param)
            : base(param)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Math.Acos(this.Parameter.Result()));
        }
    }
}
