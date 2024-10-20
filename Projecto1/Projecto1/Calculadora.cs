using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projecto1
{
    internal class Calculadora
    {
        private Dictionary<string, Func<double, double, double>> operators;
        private Dictionary<string, Func<double, double>> functions;
        private string ans;

        public Calculadora()
        {
            operators = new Dictionary<string, Func<double, double, double>>
            {
                {"+", (a, b) => a + b},
                {"-", (a, b) => a - b},
                {"*", (a, b) => a * b},
                {"/", (a, b) => a / b},
                {"^", Math.Pow}
            };

            functions = new Dictionary<string, Func<double, double>>
            {
                {"sqrt", Math.Sqrt},
                {"log", Math.Log10},
                {"ln", Math.Log}
            };

            ans = "0";
        }

        public void setAns(string ans)
        {
            this.ans = ans;
        }

        public double Evaluate(string expressionWithAns)
        {
            string expression = replaceAns(expressionWithAns);
            var tokens = Tokenize(expression);
            var postfix = ShuntingYard(tokens);
            return EvaluatePostfix(postfix);
        }

        public string replaceAns(string expressionWithAns)
        {
            return expressionWithAns.Replace("Ans", this.ans);
        }

        private List<string> Tokenize(string expression)
        {
            var tokens = new List<string>();
            var token = "";
            foreach (var c in expression.Replace(" ", ""))
            {
                if (char.IsLetterOrDigit(c) || c == '.')
                {
                    token += c;
                }
                else
                {
                    if (!string.IsNullOrEmpty(token))
                    {
                        tokens.Add(token);
                        token = "";
                    }
                    tokens.Add(c.ToString());
                }
            }
            if (!string.IsNullOrEmpty(token))
            {
                tokens.Add(token);
            }
            return tokens;
        }

        private List<string> ShuntingYard(List<string> tokens)
        {
            var output = new List<string>();
            var operatorStack = new Stack<string>();

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out _))
                {
                    output.Add(token);
                }
                else if (functions.ContainsKey(token))
                {
                    operatorStack.Push(token);
                }
                else if (token == "(")
                {
                    operatorStack.Push(token);
                }
                else if (token == ")")
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                    {
                        output.Add(operatorStack.Pop());
                    }
                    if (operatorStack.Count > 0 && operatorStack.Peek() == "(")
                    {
                        operatorStack.Pop();
                    }
                    if (operatorStack.Count > 0 && functions.ContainsKey(operatorStack.Peek()))
                    {
                        output.Add(operatorStack.Pop());
                    }
                }
                else if (operators.ContainsKey(token))
                {
                    while (operatorStack.Count > 0 && Precedence(operatorStack.Peek()) >= Precedence(token))
                    {
                        output.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
            }

            while (operatorStack.Count > 0)
            {
                output.Add(operatorStack.Pop());
            }

            return output;
        }

        private int Precedence(string op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                case "^":
                    return 3;
                default:
                    return 0;
            }
        }

        private double EvaluatePostfix(List<string> postfix)
        {
            var stack = new Stack<double>();

            foreach (var token in postfix)
            {
                if (double.TryParse(token, out double number))
                {
                    stack.Push(number);
                }
                else if (operators.ContainsKey(token))
                {
                    var b = stack.Pop();
                    var a = stack.Pop();
                    stack.Push(operators[token](a, b));
                }
                else if (functions.ContainsKey(token))
                {
                    var a = stack.Pop();
                    stack.Push(functions[token](a));
                }
            }

            return stack.Pop();
        }

    }
}
