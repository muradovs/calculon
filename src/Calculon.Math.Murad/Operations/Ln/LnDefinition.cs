namespace Calculon.Math.Murad.Operations.Ln
{
    public sealed class LnDefinition : FunctionDefinition1
    {
        private LnDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new LnDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "ln"; } }
    }
}
