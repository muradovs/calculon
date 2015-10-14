namespace Calculon.Math.Murad.Operations.Tan
{
  public class TanBuilder : UnaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Tan(this.Parameter);
        }

        public override IOperationDefinition Definition
        {
            get { return TanDefinition.Definition; }
        }
    }
}
