namespace Calculon.Math.Murad.Operations.Sin
{
    public sealed class SinDefinition : FunctionDefinition1
    {
        private SinDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new SinDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "sin"; } }
    }
}
