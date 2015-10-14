using Calculon.Math.Murad.Operations.AbsBrackets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculon.Math.Murad.Operations.Abs
{
    public sealed class AbsDefinition : FunctionDefinition1
    {
        private AbsDefinition()
        {

        }

        public static IOperationDefinition Definition { get { return Creator.Instance; } }

        private sealed class Creator
        {
            private static readonly IOperationDefinition instance = new AbsDefinition();
            public static IOperationDefinition Instance { get { return instance; } }
        }

        public override string Token { get { return "abs"; } }
    }
}
