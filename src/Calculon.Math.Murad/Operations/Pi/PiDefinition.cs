namespace Calculon.Math.Murad.Operations.Pi
{
    public sealed class PiDefinition : ConstantDefinition
    {
        private PiDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new PiDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "pi"; } }
    }
}
