namespace Calculon.Math.Murad.Operations.AbsBrackets
{
  using System;

  public class AbsBrackets : UnaryOperation
    {
        public AbsBrackets(IExpression param)
            : base(param)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(Math.Abs(this.Parameter.Result()));
        }
    }
}
