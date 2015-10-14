namespace Calculon.Math.Murad.Operations.Sqrt
{
  public class SqrtBuilder: UnaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Sqrt(this.Parameter);
        }

        public override IOperationDefinition Definition
        {
            get { return SqrtDefinition.Definition; }
        }
    }
}
