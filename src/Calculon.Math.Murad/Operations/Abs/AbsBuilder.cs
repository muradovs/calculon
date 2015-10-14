using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculon.Math.Murad.Operations.Abs
{
    public class AbsBuilder : UnaryOperationBuilder
    {
        public override IOperation Build()
        {
            return new AbsBrackets.AbsBrackets(this.Parameter);
        }

        public override IOperationDefinition Definition
        {
            get { return AbsDefinition.Definition; }
        }
    }
}
