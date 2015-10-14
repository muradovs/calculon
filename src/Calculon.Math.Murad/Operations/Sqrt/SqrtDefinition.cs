namespace Calculon.Math.Murad.Operations.Sqrt
{
    public class SqrtDefinition : FunctionDefinition1
    {
        private SqrtDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new SqrtDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "sqrt"; } }
    }
}
