namespace Calculon.Math.Murad
{
  using System;

  using Calculon.Math.Murad.Operations;

  public abstract class UnaryOperationBuilder: IOperationBuilder
    {
        protected IExpression Parameter;

        public void PushParameter(IExpression param)
        {
            if (this.Parameter == null)
            {
                this.Parameter = param;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public bool IsEnoughParameters
        {
            get { return this.Parameter != null; }
        }

        public abstract IOperation Build();

        public abstract IOperationDefinition Definition { get; }
    }
}
