namespace Calculon.Math.Murad.Operations.Minus
{
  public class Minus : BinaryOperation
    {
        public Minus(IExpression param1, IExpression param2) :
            base(param1, param2)
        {

        }

        #region IOperation Members

        public override IExpression Calculate()
        {
            return new SimpleExpression(this.Parameter1.Result() - this.Parameter2.Result());
        }

        #endregion
    }
}
