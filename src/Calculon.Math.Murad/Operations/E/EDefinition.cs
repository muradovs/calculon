namespace Calculon.Math.Murad.Operations.E
{
    public sealed class EDefinition : ConstantDefinition
    {
        private EDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new EDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "e"; } }
    }
}
