namespace Calculon.Math.Murad.Operations.Actan
{
    public sealed class ActanDefinition : FunctionDefinition1
    {
        private ActanDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new ActanDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "actan"; } }
    }
}
