namespace Calculon.Math.Murad.Operations.Max
{
    public sealed class MaxDefinition : FunctionDefinition2
    {
        private MaxDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new MaxDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "max"; } }
    }
}
