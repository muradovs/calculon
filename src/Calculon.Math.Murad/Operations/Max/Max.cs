namespace Calculon.Math.Murad.Operations.Max
{
  using System;

  public sealed class Max: BinaryOperation
    {
        public Max(IExpression param1, IExpression param2)
            : base(param1, param2)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Math.Max(this.Parameter1.Result(), this.Parameter2.Result()));
        }
    }
}
