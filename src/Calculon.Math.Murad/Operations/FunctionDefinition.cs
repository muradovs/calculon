namespace Calculon.Math.Murad.Operations
{
    public abstract class FunctionDefinition : IOperationDefinition
    {
        private static readonly Associativity associativity = Associativity.Right;
        private static readonly OperationType type = OperationType.Agregator;
        private static readonly ParameterOrder parameterOrder = ParameterOrder.Inner;

        public abstract int ParameterCount
        {
            get;
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
