namespace Calculon.Math.Murad.Operations.Max
{
  public sealed class MaxBuilder : BinaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Max(this.paramLeft, this.paramRight);
        }

        public override IOperationDefinition Definition
        {
            get { return MaxDefinition.Definition; }
        }
    }
}
