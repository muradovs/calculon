namespace Calculon.Math.Murad.Operations.Plus
{
  public sealed class PlusBuilder : BinaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Plus(this.paramLeft, this.paramRight);
        }

        public override IOperationDefinition Definition { get { return PlusDefinition.Definition; } }
    }
}
