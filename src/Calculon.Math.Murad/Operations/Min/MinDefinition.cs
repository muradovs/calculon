namespace Calculon.Math.Murad.Operations.Min
{
    public sealed class MinDefinition : FunctionDefinition2
    {
        private MinDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new MinDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "min"; } }
    }
}
