namespace Calculon.Math.Murad
{
  using Calculon.Math.Murad.Operations;

  public abstract class BinaryOperation : IOperation
    {
        public IExpression Parameter1 { get; protected set; }

        public IExpression Parameter2 { get; protected set; }

        protected BinaryOperation(IExpression param1, IExpression param2)
        {
            this.Parameter1 = param1;
            this.Parameter2 = param2;
        }

        #region IOperation Members

        public abstract IExpression Calculate();

        #endregion
    }
}
