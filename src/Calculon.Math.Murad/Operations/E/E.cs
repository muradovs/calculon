namespace Calculon.Math.Murad.Operations.E
{
  using System;

  public class E: IOperation
    {
        public IExpression Calculate()
        {
            return new SimpleExpression(Math.E);
        }
    }
}
