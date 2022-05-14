using System;
using System.Collections.Generic;  

namespace RandomProblem
{
    class RandomProblem {         

        static void print(List<List<string>> probList) 
        {
            foreach (var singProb in probList)
            {
                Console.WriteLine("<"+string.Join(", ", singProb)+">");
            }
        }

        static List<String> getRandProb() 
        {
            List<string> singProb = new List<string>();
            string operatorString;
            int const2, const4;


            // Selecting random answer, constants and operator
            Random rnd = new Random();
            int ans = rnd.Next(1, 30);
            int const1 = rnd.Next(1, ans);
            int const3 = rnd.Next(1, ans);
            int const5 = rnd.Next(const1, ans);
            var operation = rnd.Next(1, 3);  

            singProb.Add(ans.ToString());

            switch (operation)
            {
                case 1:
                    operatorString = "+";
                    singProb.Add(operatorString);
                    const2 = ans - const1;
                    const4 = ans - const3;
                    break;
                case 2:
                    operatorString = "-";
                    singProb.Add(operatorString);
                    const2 = ans + const1;
                    const4 = ans + const3;
                    break;
                default:
                    operatorString = "?";
                    return singProb;
            }

            singProb.Add(const1.ToString());
            singProb.Add(const2.ToString());
            singProb.Add(const3.ToString());
            singProb.Add(const4.ToString());
            singProb.Add(const5.ToString());

            return singProb;

        }

        static void Main(string[] args)
        {
            List<List<string>> probList = new List<List<string>>();
            for (int i = 0; i < 10; i++) 
            {
                // Singular problem
                List<string> singProb = getRandProb();
                probList.Add(singProb);
            }

            print(probList);
        }
    }
}
