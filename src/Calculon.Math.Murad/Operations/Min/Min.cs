namespace Calculon.Math.Murad.Operations.Min
{
  using System;

  public sealed class Min: BinaryOperation
    {
        public Min(IExpression param1, IExpression param2)
            : base(param1, param2)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Math.Min(this.Parameter1.Result(), this.Parameter2.Result()));
        }
    }
}
