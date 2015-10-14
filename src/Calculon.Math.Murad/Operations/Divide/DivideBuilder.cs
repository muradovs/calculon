namespace Calculon.Math.Murad.Operations.Divide
{
  public class DivideBuilder: BinaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Divide(this.paramLeft, this.paramRight);
        }

        public override IOperationDefinition Definition
        {
            get { return DivideDefinition.Definition; }
        }
    }
}
