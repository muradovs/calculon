namespace Calculon.Math.Murad.Operations.Lg
{
    public sealed class LgDefinition : FunctionDefinition1
    {
        private LgDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new LgDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "lg"; } }
    }
}
