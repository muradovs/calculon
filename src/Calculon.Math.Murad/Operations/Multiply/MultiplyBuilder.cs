namespace Calculon.Math.Murad.Operations.Multiply
{
  public class MultiplyBuilder : BinaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Multiply(this.paramLeft, this.paramRight);
        }

        public override IOperationDefinition Definition
        {
            get { return MultiplyDefinition.Definition; }
        }
    }
}
