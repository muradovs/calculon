namespace Calculon.Math.Murad.Operations.Tan
{
    public sealed class TanDefinition : FunctionDefinition1
    {
        private TanDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new TanDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "tan"; } }
    }
}
