namespace Calculon.Math.Murad.Operations.Log
{
  public class LogBuilder : BinaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new Log(this.paramLeft, this.paramRight);
        }

        public override IOperationDefinition Definition
        {
            get { return LogDefinition.Definition; }
        }
    }
}
