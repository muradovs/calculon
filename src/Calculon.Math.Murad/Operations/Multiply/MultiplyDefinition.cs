namespace Calculon.Math.Murad.Operations.Multiply
{
    public class MultiplyDefinition : BinaryOperationDefinition
    {
        private MultiplyDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new MultiplyDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "*"; } }
    }
}
