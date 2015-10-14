namespace Calculon.Math.Murad.Operations.Power
{
  public class PowerBuilder : BinaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Power(this.paramLeft, this.paramRight);
        }

        public override IOperationDefinition Definition
        {
            get { return PowerDefinition.Definition; }
        }
    }
}
