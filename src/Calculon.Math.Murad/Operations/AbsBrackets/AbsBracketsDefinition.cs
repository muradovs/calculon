namespace Calculon.Math.Murad.Operations.AbsBrackets
{
    public sealed class AbsBracketsDefinition : FunctionDefinition1
    {
        private AbsBracketsDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new AbsBracketsDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "|"; } }
    }
}
