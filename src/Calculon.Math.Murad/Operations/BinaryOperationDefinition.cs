using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculon.Math.Murad.Operations
{
    public abstract class BinaryOperationDefinition : IOperationDefinition
    {
        private static readonly int parameterCount = 2;
        private static readonly Associativity associativity = Associativity.Left;
        private static readonly OperationType type = OperationType.Operator;
        private static readonly ParameterOrder parameterOrder = ParameterOrder.LeftRight;

        public int ParameterCount
        {
            get { return parameterCount; }
        }

        public Associativity Associativity
        {
            get { return associativity; }
        }

        public OperationType Type { get { return type; } }

        public ParameterOrder ParameterOrder { get { return parameterOrder; } }

        public abstract string Token { get; }
    }
}
