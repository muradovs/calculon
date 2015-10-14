using Calculon.Math.Murad.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculon.Math.Murad
{
    public class OpenedUnarOperatorException: Exception
    {
        public IOperationDefinition Definition { get; private set; }

        public OpenedUnarOperatorException(IOperationDefinition definition)
            : base("Unar operator can't be opened")
        {
            this.Definition = definition;
        }
    }
}
