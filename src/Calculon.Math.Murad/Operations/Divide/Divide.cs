namespace Calculon.Math.Murad.Operations.Divide
{
  public class Divide: BinaryOperation
    {
        public Divide(IExpression param1, IExpression param2)
            : base(param1, param2)
        {

        }

        public override IExpression Calculate()
        {
            return new SimpleExpression(this.Parameter1.Result() / this.Parameter2.Result());
        }
    }
}
