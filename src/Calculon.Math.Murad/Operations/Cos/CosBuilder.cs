namespace Calculon.Math.Murad.Operations.Cos
{
  public class CosBuilder : UnaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Cos(this.Parameter);
        }

        public override IOperationDefinition Definition
        {
            get { return CosDefinition.Definition; }
        }
    }
}
