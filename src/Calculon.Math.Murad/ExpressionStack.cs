namespace Calculon.Math.Murad
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  using Calculon.Math.Murad.Operations;

    public class ExpressionStack
    {
        private Stack<IOperationBuilder> stack = new Stack<IOperationBuilder>();
        private IExpression preParam;
        private OperationPriorityComparer comparer;

        public ExpressionStack(OperationPriorityComparer priorityComparer)
        {
            comparer = priorityComparer;
        }

        public void Push(IExpression expression)
        {
            if (preParam != null)
            {
                do
                {
                    stack.First().PushParameter(preParam);
                    preParam = null;
                    if (stack.First().IsEnoughParameters)
                    {
                        preParam = new CalculableExpression(stack.Pop().Build());
                    }
                }
                while (preParam != null && stack.Any());
            }

            if (preParam != null)
            {
                throw new InvalidOperationException();
            }

            preParam = expression;
        }

        public void Push(IOperationBuilder operationBuilder)
        {
            if (preParam == null && operationBuilder.Definition.Type == OperationType.Operator &&
                ((operationBuilder.Definition.ParameterOrder & ParameterOrder.LeftRight) == ParameterOrder.LeftRight || (operationBuilder.Definition.ParameterOrder & ParameterOrder.Left) == ParameterOrder.Left))
            {
                throw new Exception("there must be expression or number");
            }

            if (operationBuilder.IsEnoughParameters)
            {
                Push(new CalculableExpression(operationBuilder.Build()));
                return;
            }

            if (preParam == null && operationBuilder.Definition.Type == OperationType.Operator)
            {
                if ((!stack.Any() || stack.First().Definition.Type != OperationType.Agregator) && (operationBuilder.Definition.ParameterOrder & ParameterOrder.Right) == ParameterOrder.Right)
                {
                    throw new OpenedUnarOperatorException(operationBuilder.Definition);
                }

                if ((operationBuilder.Definition.ParameterOrder & ParameterOrder.Right) != ParameterOrder.Right)
                {
                    throw new Exception("there is no appropriate unar operator");
                }

                if (operationBuilder.Definition.Token == "-" || operationBuilder.Definition.Token == "+")
                {
                    operationBuilder.PushParameter(new SimpleExpression(0));
                }
            }

            while (preParam != null && operationBuilder.Definition.Type == OperationType.Operator)
            {
                if (!stack.Any())
                {
                    operationBuilder.PushParameter(preParam);
                    preParam = null;
                }
                else
                {
                    var first = stack.First();

                    if (first.Definition.Type == OperationType.Agregator || comparer.IsLess(first.Definition, operationBuilder.Definition) || operationBuilder.Definition.Associativity == Associativity.Right)
                    {
                        operationBuilder.PushParameter(preParam);
                        preParam = null;
                    }
                    else
                    {
                        first.PushParameter(preParam);
                        preParam = null;

                        if (first.IsEnoughParameters && !comparer.IsLess(first.Definition, operationBuilder.Definition))
                        {
                            var item = stack.Pop();
                            preParam = new CalculableExpression(item.Build());
                        }
                    }
                }
            }

            stack.Push(operationBuilder);
        }

        public bool TryCompleteAgregate()
        {
            if (preParam != null)
            {
                stack.First().PushParameter(preParam);
                preParam = null;

                if (stack.First().IsEnoughParameters && stack.First().Definition.Type == OperationType.Agregator)
                {
                    var item = stack.Pop();
                    preParam = new CalculableExpression(item.Build());
                    return true;
                }
            }

            if (stack.Any() && stack.First().IsEnoughParameters && stack.First().Definition.Type != OperationType.Agregator)
            {
                while (stack.First().IsEnoughParameters && stack.First().Definition.Type != OperationType.Agregator)
                {
                    var item = stack.Pop();
                    stack.First().PushParameter(new CalculableExpression(item.Build()));
                }

                if (stack.First().IsEnoughParameters && stack.First().Definition.Type == OperationType.Agregator)
                {
                    var item = stack.Pop();
                    preParam = new CalculableExpression(item.Build());
                    return true;
                }
            }

            return false;
        }

        public bool CompleteAgregate()
        {
            if (!TryCompleteAgregate())
                if (!stack.First().IsEnoughParameters)
                {
                    throw new Exception("not enough parameters in " + stack.First().GetType());
                }
                else
                {
                    throw new Exception("expression is not completed");
                }

            return true;
        }

        public IExpression CreateExpression()
        {
            if (preParam != null && !stack.Any())
                return preParam;

            if (preParam != null && stack.Any())
            {
                stack.First().PushParameter(preParam);
                preParam = null;
            }

            var paramStack = new Stack<IOperationBuilder>();

            while (stack.Any())
            {
                var item = stack.Pop();

                while (!item.IsEnoughParameters)
                {
                    item.PushParameter(new CalculableExpression(paramStack.Pop().Build()));
                }

                paramStack.Push(item);
            }

            return new CalculableExpression(paramStack.Pop().Build());
        }
    }
}
