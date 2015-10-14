namespace Calculon.Math.Murad.Operations.Plus
{
    public class PlusDefinition : IOperationDefinition
    {
        private PlusDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new PlusDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        private static readonly int parameterCount = 2;
        private static readonly Associativity associativity = Associativity.Left;
        private static readonly OperationType type = OperationType.Operator;
        private static readonly ParameterOrder parameterOrder = ParameterOrder.Right & ParameterOrder.LeftRight;

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

        public string Token { get { return "+"; } }
    }
}
