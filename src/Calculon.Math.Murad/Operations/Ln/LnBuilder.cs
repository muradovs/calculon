namespace Calculon.Math.Murad.Operations.Ln
{
  public sealed class LnBuilder : UnaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Ln(this.Parameter);
        }

        public override IOperationDefinition Definition
        {
            get { return LnDefinition.Definition; }
        }
    }
}
