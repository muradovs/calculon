namespace Calculon.Math.Murad.Operations.Ln
{
  using System;

  public sealed class Ln : UnaryOperation
    {
        public Ln(IExpression param)
            : base(param)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Math.Log(this.Parameter.Result(), Math.E));
        }
    }
}
