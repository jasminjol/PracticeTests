using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringToMathematicalExpression
{
    public class MathematicalExpression
    {
        public int Evaluate(string expression)
        {
            char[] tokens = expression.ToCharArray();

            Stack<int> numStack = new Stack<int>();
            Stack<char> opStack = new Stack<char>();

            for(int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == ' ')
                    continue;

                if (tokens[i] >= '0' && tokens[i] <= '9')
                {
                    StringBuilder sb = new StringBuilder();

                    while (i < tokens.Length && tokens[i] >= '0' && tokens[i] <= '9')
                    {
                        sb.Append(tokens[i++]);
                    }
                    numStack.Push(int.Parse(sb.ToString()));
                }
                else if (tokens[i] == '(')
                {
                    opStack.Push(tokens[i]);
                }

                else if (tokens[i] == ')')
                {
                    while (opStack.Peek() != '(')
                    {
                        numStack.Push(ApplyOperator(opStack.Pop(), numStack.Pop(), numStack.Pop()));
                    }
                    opStack.Pop();
                }
                else if (tokens[i] == '+' || tokens[i] == '-' || tokens[i] == '*' || tokens[i] == '/')
                {
                    while (opStack.Count > 0 && HasPrecedence(tokens[i], opStack.Peek()))
                    {
                        numStack.Push(ApplyOperator(opStack.Pop(), numStack.Pop(), numStack.Pop()));
                    }
                    opStack.Push(tokens[i]);
                }
            }

            while (opStack.Count > 0)
            {
                numStack.Push(ApplyOperator(opStack.Pop(), numStack.Pop(), numStack.Pop()));
            }

            return numStack.Pop();
        }
        private bool HasPrecedence(char op1, char op2)
        {
            if (op2 == '(' || op2 == ')')
                return false;

            if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
                return false;

            return true;
        }
        private int ApplyOperator(char op, int num2, int num1)
        {
            switch (op)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    if (num2 == 0)
                        throw new System.ArithmeticException("Cannot divide by zero");

                    return num1 / num2;
            }
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MathematicalExpression mathExp = new MathematicalExpression();

            Console.WriteLine("20 + 2 * 6 = " + mathExp.Evaluate("20 + 2 * 6"));
            Console.WriteLine("100 * ( 4 + 15 ) = " + mathExp.Evaluate("100 * ( 4 + 15 )"));
            Console.WriteLine("100 * ( 2 + 12 ) = "+ mathExp.Evaluate("100 * ( 2 + 12 )"));
            Console.WriteLine("200 * ( 2 + 12 ) / 14 = "+ mathExp.Evaluate("100 * ( 2 + 12 ) / 14"));
            Console.WriteLine("( 100 / 4 ) * ( 2 + 12 )= " + mathExp.Evaluate("( 100 / 4 ) * ( 2 + 12 )"));
            Console.ReadKey();
        }
    }
}
