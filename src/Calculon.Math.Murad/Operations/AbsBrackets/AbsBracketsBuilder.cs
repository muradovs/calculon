namespace Calculon.Math.Murad.Operations.AbsBrackets
{
  public class AbsBracketsBuilder : UnaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new AbsBrackets(this.Parameter);
        }

        public override IOperationDefinition Definition
        {
            get { return AbsBracketsDefinition.Definition; }
        }
    }
}
