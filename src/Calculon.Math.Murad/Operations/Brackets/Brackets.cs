namespace Calculon.Math.Murad.Operations.Brackets
{
  public class Brackets: UnaryOperation
    {
        public Brackets(IExpression param)
            : base(param)
        {

        }

        public override IExpression Calculate()
        {
            return this.Parameter;
        }
    }
}
