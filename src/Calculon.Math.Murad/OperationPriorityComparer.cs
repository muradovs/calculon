namespace Calculon.Math.Murad
{
  using System;
  using System.Collections.Generic;

  using Calculon.Math.Murad.Operations;

  public class OperationPriorityComparer
    {
        private readonly IEnumerable<IOperationDefinition> priorityList;

        public OperationPriorityComparer(IEnumerable<IOperationDefinition> operationDefinitions)
        {
            this.priorityList = operationDefinitions;
        }

        public bool IsLess(IOperationDefinition param1, IOperationDefinition param2)
        {
            if (param1 == param2)
                return false;

            foreach (var def in this.priorityList)
            {
                if (def == param1)
                {
                    return false;
                }

                if (def == param2)
                {
                    return true;
                }
            }

            throw new InvalidOperationException();
        }

        public bool IsGreater(IOperationDefinition param1, IOperationDefinition param2)
        {
            if (param1 == param2)
                return false;

            return !this.IsLess(param1, param2);
        }
    }
}
