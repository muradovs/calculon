namespace Calculon.Math.Murad.Operations.Divide
{
    public sealed class DivideDefinition : BinaryOperationDefinition
    {
        private DivideDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new DivideDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "/"; } }
    }
}
