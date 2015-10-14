namespace Calculon.Math.Murad
{
  using Calculon.Math.Murad.Operations;

  public class CalculableExpression : IExpression
    {
        public CalculableExpression(IOperation operation)
        {
            this.Operation = operation;
        }

        public double Result()
        {
            return this.Operation.Calculate().Result();
        }

        protected IOperation Operation { get; set; }
    }
}
