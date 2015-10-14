namespace Calculon.Math.Murad.Operations.Min
{
  public sealed class MinBuilder : BinaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Min(this.paramLeft, this.paramRight);
        }

        public override IOperationDefinition Definition
        {
            get { return MinDefinition.Definition; }
        }
    }
}
