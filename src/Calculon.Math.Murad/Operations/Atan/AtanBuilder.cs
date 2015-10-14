namespace Calculon.Math.Murad.Operations.Atan
{
  public sealed class AtanBuilder : UnaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Atan(this.Parameter);
        }

        public override IOperationDefinition Definition
        {
            get { return AtanDefinition.Definition; }
        }
    }
}
