namespace Calculon.Math.Murad.Operations.Brackets
{
    public sealed class BracketsDefinition : FunctionDefinition1
    {
        private BracketsDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new BracketsDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "("; } }
    }
}
