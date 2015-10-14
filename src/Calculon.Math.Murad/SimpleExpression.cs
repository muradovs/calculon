namespace Calculon.Math.Murad
{
  public class SimpleExpression : IExpression
    {
        protected double Number { get; set; }

        public SimpleExpression(double number)
        {
            this.Number = number;
        }

        public double Result()
        {
            return this.Number;
        }
    }
}
