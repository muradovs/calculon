namespace Calculon.Math.Murad.Operations
{
    public abstract class ConstantDefinition : IOperationDefinition
    {
        private static readonly int parameterCount = 0;
        private static readonly Associativity associativity = Associativity.Right;
        private static readonly OperationType type = OperationType.Constant;
        private static readonly ParameterOrder parameterOrder = ParameterOrder.Inner;

        public int ParameterCount
        {
            get { return parameterCount; }
        }

        public Associativity Associativity
        {
            get { return associativity; }
        }

        public OperationType Type { get { return type; } }

        public ParameterOrder ParameterOrder { get { return parameterOrder; } }

        public abstract string Token { get; }
    }
}
