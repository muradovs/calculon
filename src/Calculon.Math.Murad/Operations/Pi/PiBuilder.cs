namespace Calculon.Math.Murad.Operations.Pi
{
  using System;

  public class PiBuilder : IOperationBuilder
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
            return new Pi();
        }

        public IOperationDefinition Definition
        {
            get { return PiDefinition.Definition; }
        }
    }
}
