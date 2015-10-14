namespace Calculon.Math.Murad.Operations.Cos
{
    public sealed class CosDefinition : FunctionDefinition1
    {
        private CosDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new CosDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "cos"; } }
    }
}
