namespace Calculon.Math.Murad.Operations.Ctan
{
  public sealed class CtanBuilder : UnaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Ctan(this.Parameter);
        }

        public override IOperationDefinition Definition
        {
            get { return CtanDefinition.Definition; }
        }
    }
}
