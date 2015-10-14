namespace Calculon.Math.Murad.Operations.Acos
{
    public sealed class AcosDefinition : FunctionDefinition1
    {
        private AcosDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new AcosDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "acos"; } }
    }
}
