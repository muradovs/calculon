namespace Calculon.Math.Murad.Operations.Pi
{
  using System;

  public class Pi : IOperation
    {
        public IExpression Calculate()
        {
            return new SimpleExpression(Math.PI);
        }
    }
}
