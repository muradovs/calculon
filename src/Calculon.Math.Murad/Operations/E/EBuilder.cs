namespace Calculon.Math.Murad.Operations.E
{
  using System;

  public class EBuilder: IOperationBuilder
    {
        public void PushParameter(IExpression param)
        {
            throw new InvalidOperationException();
        }

        public bool IsEnoughParameters
        {
            get { return true; }
        }

        public IOperation Build()
        {
            return new E();
        }

        public IOperationDefinition Definition
        {
            get { return EDefinition.Definition; }
        }
    }
}
