namespace Calculon.Math.Murad.Operations.Brackets
{
  public class BracketsBuilder : UnaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Brackets(this.Parameter);
        }

        public override IOperationDefinition Definition
        {
            get { return BracketsDefinition.Definition; }
        }
    }
}
