namespace Calculon.Math.Murad.Operations.Acos
{
  public sealed class AcosBuilder : UnaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Acos(this.Parameter);
        }

        public override IOperationDefinition Definition
        {
            get { return AcosDefinition.Definition; }
        }
    }
}
