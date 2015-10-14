namespace Calculon.Math.Murad.Operations.Asin
{
  public sealed class AsinBuilder : UnaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Asin(this.Parameter);
        }

        public override IOperationDefinition Definition
        {
            get { return AsinDefinition.Definition; }
        }
    }
}
