using Calculon.Math.Murad.Operations;
using Calculon.Math.Murad.Operations.Abs;
using Calculon.Math.Murad.Operations.AbsBrackets;
using Calculon.Math.Murad.Operations.Acos;
using Calculon.Math.Murad.Operations.Actan;
using Calculon.Math.Murad.Operations.Asin;
using Calculon.Math.Murad.Operations.Atan;
using Calculon.Math.Murad.Operations.Brackets;
using Calculon.Math.Murad.Operations.Cos;
using Calculon.Math.Murad.Operations.Ctan;
using Calculon.Math.Murad.Operations.Divide;
using Calculon.Math.Murad.Operations.E;
using Calculon.Math.Murad.Operations.Lg;
using Calculon.Math.Murad.Operations.Ln;
using Calculon.Math.Murad.Operations.Log;
using Calculon.Math.Murad.Operations.Max;
using Calculon.Math.Murad.Operations.Min;
using Calculon.Math.Murad.Operations.Minus;
using Calculon.Math.Murad.Operations.Multiply;
using Calculon.Math.Murad.Operations.Pi;
using Calculon.Math.Murad.Operations.Plus;
using Calculon.Math.Murad.Operations.Power;
using Calculon.Math.Murad.Operations.Sin;
using Calculon.Math.Murad.Operations.Sqrt;
using Calculon.Math.Murad.Operations.Tan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculon.Math.Murad.Operations
{
    public class OperationFactory
    {
        private static readonly IDictionary<IOperationDefinition, Func<IOperationBuilder>> operations = new Dictionary<IOperationDefinition, Func<IOperationBuilder>>
        {
            { EDefinition.Definition, ()=>{ return new EBuilder(); } },
            { PiDefinition.Definition, ()=>{ return new PiBuilder(); } },
            { SinDefinition.Definition, ()=>{ return new SinBuilder(); } },
            { AsinDefinition.Definition, ()=>{ return new AsinBuilder(); } },
            { CosDefinition.Definition, ()=>{ return new CosBuilder(); } },
            { AcosDefinition.Definition, ()=>{ return new AcosBuilder(); } },
            { TanDefinition.Definition, ()=>{ return new TanBuilder(); } },
            { AtanDefinition.Definition, ()=>{ return new AtanBuilder(); } },
            { CtanDefinition.Definition, ()=>{ return new CtanBuilder(); } },
            { ActanDefinition.Definition, ()=>{ return new ActanBuilder(); } },
            { MaxDefinition.Definition, ()=>{ return new MaxBuilder(); } },
            { MinDefinition.Definition, ()=>{ return new MinBuilder(); } },
            { SqrtDefinition.Definition, ()=>{ return new SqrtBuilder(); } },
            { LogDefinition.Definition, ()=>{ return new LogBuilder(); } },
            { LgDefinition.Definition, ()=>{ return new LgBuilder(); } },
            { LnDefinition.Definition, ()=>{ return new LnBuilder(); } },
            { AbsBracketsDefinition.Definition, ()=>{ return new AbsBracketsBuilder(); } },
            { BracketsDefinition.Definition, ()=>{ return new BracketsBuilder(); } },
            { PowerDefinition.Definition, ()=>{ return new PowerBuilder(); } },
            { DivideDefinition.Definition, ()=>{ return new DivideBuilder(); } },
            { MultiplyDefinition.Definition, ()=>{ return new MultiplyBuilder(); } },
            { MinusDefinition.Definition, ()=>{ return new MinusBuilder(); } },
            { PlusDefinition.Definition, ()=>{ return new PlusBuilder(); } }
        };

        public IEnumerable<IOperationDefinition> Definitions
        {
            get { return operations.Keys; }
        }

        public IOperationBuilder Create(IOperationDefinition definition)
        {
            return operations[definition].Invoke();
        }
    }
}
