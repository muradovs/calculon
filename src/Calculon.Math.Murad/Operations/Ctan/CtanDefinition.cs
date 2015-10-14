namespace Calculon.Math.Murad.Operations.Ctan
{
    public sealed class CtanDefinition : FunctionDefinition1
    {
        private CtanDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new CtanDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "ctan"; } }
    }
}
