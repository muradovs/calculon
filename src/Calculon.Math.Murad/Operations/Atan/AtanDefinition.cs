namespace Calculon.Math.Murad.Operations.Atan
{
    public sealed class AtanDefinition : FunctionDefinition1
    {
        private AtanDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new AtanDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "atan"; } }
    }
}
