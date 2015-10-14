namespace Calculon.Math.Murad.Operations.Asin
{
    public sealed class AsinDefinition : FunctionDefinition1
    {
        private AsinDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new AsinDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "asin"; } }
    }
}
