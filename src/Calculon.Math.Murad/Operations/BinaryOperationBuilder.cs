namespace Calculon.Math.Murad
{
  using System;

  using Calculon.Math.Murad.Operations;

  public abstract class BinaryOperationBuilder: IOperationBuilder
    {
        protected IExpression paramLeft, paramRight;

        public void PushParameter(IExpression param)
        {
            if (this.paramLeft == null)
            {
                this.paramLeft = param;
            }
            else if (this.paramRight == null)
            {
                this.paramRight = param;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public bool IsEnoughParameters
        {
            get { return this.paramLeft != null && this.paramRight != null; }
        }

        public abstract IOperation Build();

        public abstract IOperationDefinition Definition { get; }
    }
}
