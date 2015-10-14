namespace Calculon.Math.Murad.Operations.Sin
{
  public sealed class SinBuilder : UnaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Sin(this.Parameter);
        }

        public override IOperationDefinition Definition
        {
            get { return SinDefinition.Definition; }
        }
    }
}
