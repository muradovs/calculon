namespace Calculon.Math.Murad.Operations.Sin
{
  using System;

  public sealed class Sin : UnaryOperation
    {
        public Sin(IExpression param)
            : base(param)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Math.Sin(this.Parameter.Result()));
        }
    }
}
