namespace Calculon.Math.Murad.Operations.Log
{
    public sealed class LogDefinition : FunctionDefinition2
    {
        private LogDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new LogDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "log"; } }
    }
}
