namespace Calculon.Math.Murad
{
    using Calculon.Math.Murad.Operations;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

  public sealed class ExpressionParser
    {
        public static IExpression Parse(string expression)
        {
            return new ExpressionParser(new OperationFactory()).ParseWithCustomTokens(expression);
        }

        private OperationFactory factory;
        private OperationPriorityComparer comparer;

        public ExpressionParser(OperationFactory operationFactory)
        {
            this.factory = operationFactory;
            
            this.comparer = new OperationPriorityComparer(this.factory.Definitions);
        }

        public IExpression ParseWithCustomTokens(string expression)
        {
            var stack = new ExpressionStack(comparer);

            for (int i = 0; i < expression.Length; )
            {
                while (i < expression.Length && char.IsWhiteSpace(expression[i])) i++;

                if (char.IsDigit(expression[i]))
                {
                    var sb = new StringBuilder();
                    while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        sb.Append(expression[i]);
                        i++;
                    }

                    stack.Push(new SimpleExpression(Convert.ToDouble(sb.ToString(), CultureInfo.InvariantCulture)));
                }

                try
                {

                    while (i < expression.Length && char.IsWhiteSpace(expression[i])) i++;

                    while (i < expression.Length && (expression[i] == ')' || expression[i] == '|'))
                    {
                        bool res = false;
                        if (expression[i] == ')')
                            res = stack.CompleteAgregate();
                        else if (expression[i] == '|')
                            res = stack.TryCompleteAgregate();

                        if (res)
                            i++;
                        else
                            break;
                    }

                    while (i < expression.Length && char.IsWhiteSpace(expression[i])) i++;

                    bool isFound = false;

                    if (i < expression.Length && expression[i] == ',')
                    {
                        stack.TryCompleteAgregate();
                        i++;
                        isFound = true;
                    }

                    while (i < expression.Length && char.IsWhiteSpace(expression[i])) i++;



                    // for functions and constants
                    if (i < expression.Length && char.IsLetter(expression[i]))
                    {
                        var tokenBuilder = new StringBuilder();
                        while (i < expression.Length && char.IsLetterOrDigit(expression[i]))
                        {
                            tokenBuilder.Append(expression[i]);
                            i++;
                        }

                        if (i < expression.Length && expression[i] == '(')
                        {
                            i++;
                        }

                        var t = tokenBuilder.ToString();
                        foreach (var token in this.factory.Definitions)
                        {
                            if (token.Token == t)
                            {
                                stack.Push(this.factory.Create(token));
                                isFound = true;
                                break;
                            }
                        }
                    }

                    while (i < expression.Length && char.IsWhiteSpace(expression[i])) i++;

                    // for operators and pure agregators
                    {
                        var tokenBuilder = new StringBuilder();
                        while (!isFound && i < expression.Length && !(char.IsDigit(expression[i]) || expression[i] == '.' || char.IsLetter(expression[i]) || expression[i] == ','))
                        {
                            tokenBuilder.Append(expression[i]);
                            var t = tokenBuilder.ToString();
                            foreach (var token in this.factory.Definitions)
                            {
                                if (token.Token == t)
                                {
                                    stack.Push(this.factory.Create(token));
                                    isFound = true;
                                    break;
                                }
                            }
                            i++;
                        }
                    }

                    if (!isFound && i < expression.Length)
                        throw new Exception("there must be operator, function or open bracket!");
                }
                catch (Exception ex)
                {
                    throw new Exception("Character = " + (i + 1) + ":" + ex.Message);
                }
            }

            return stack.CreateExpression();
        }
    }
}
