namespace Calculon.Math.Murad.Operations.Minus
{
  public class MinusBuilder : BinaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Minus(this.paramLeft, this.paramRight);
        }

        public override IOperationDefinition Definition
        {
            get
            {
                return MinusDefinition.Definition;
            }
        }
    }
}
