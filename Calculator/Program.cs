using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = "";
                while (true)
                {
                    StringBuilder text = new StringBuilder();
                    Console.Write("Input expression (type 'exit' to quit): ");

                    input = Console.ReadLine();
                    if(input == "exit")
                    {
                        break;
                    }
                    text.Append(input);

                    AntlrInputStream inputStream = new AntlrInputStream(text.ToString());
                    ArithmeticLexer arithmeticLexer = new ArithmeticLexer(inputStream);
                    CommonTokenStream commonTokenStream = new CommonTokenStream(arithmeticLexer);
                    ArithmeticParser arithmeticParser = new ArithmeticParser(commonTokenStream);

                    ArithmeticParser.ExpressionContext expressionContext = arithmeticParser.expression();
                    TreeEvaluator evaluator = new TreeEvaluator();
                    double result = evaluator.Visit(expressionContext);
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
    }
}
