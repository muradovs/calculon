namespace Calculon.Math.Murad.Operations.Lg
{
  public sealed class LgBuilder : UnaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Lg(this.Parameter);
        }

        public override IOperationDefinition Definition
        {
            get { return LgDefinition.Definition; }
        }
    }
}
