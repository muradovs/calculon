namespace Calculon.Math.Murad
{
  using Calculon.Math.Murad.Operations;

  public abstract class UnaryOperation : IOperation
    {
        public IExpression Parameter { get; protected set; }

        protected UnaryOperation(IExpression param)
        {
            this.Parameter = param;
        }

        #region IOperation Members

        public abstract IExpression Calculate();

        #endregion
    }
}
