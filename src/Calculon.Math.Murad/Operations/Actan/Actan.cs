namespace Calculon.Math.Murad.Operations.Actan
{
  public sealed class Actan : UnaryOperation
    {
        public Actan(IExpression param)
            : base(param)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression((System.Math.PI * 0.5) - System.Math.Atan(this.Parameter.Result()));
        }
    }
}
