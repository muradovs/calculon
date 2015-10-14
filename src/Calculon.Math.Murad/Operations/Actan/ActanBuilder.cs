namespace Calculon.Math.Murad.Operations.Actan
{
  public sealed class ActanBuilder : UnaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Actan(this.Parameter);
        }

        public override IOperationDefinition Definition
        {
            get { return ActanDefinition.Definition; }
        }
    }
}
