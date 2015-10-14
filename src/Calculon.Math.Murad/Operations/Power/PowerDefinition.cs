namespace Calculon.Math.Murad.Operations.Power
{
    public class PowerDefinition : IOperationDefinition
    {
        private PowerDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new PowerDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        private static readonly int parameterCount = 2;
        private static readonly Associativity associativity = Associativity.Right;
        private static readonly OperationType type = OperationType.Operator;
        private static readonly ParameterOrder parameterOrder = ParameterOrder.LeftRight;

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

        public string Token { get { return "^"; } }
    }
}
