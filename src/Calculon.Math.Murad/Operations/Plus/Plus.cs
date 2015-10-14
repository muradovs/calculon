namespace Calculon.Math.Murad.Operations.Plus
{
  public class Plus : BinaryOperation
    {
        public Plus(IExpression param1, IExpression param2) :
            base(param1, param2)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(this.Parameter1.Result() + this.Parameter2.Result());
        }
    }
}
