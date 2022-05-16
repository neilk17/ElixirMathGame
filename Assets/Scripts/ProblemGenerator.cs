using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    int currentLevel = 1;
    List<List<string>> problemSpace = new List<List<string>>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<List<string>> getProblemSpace(int level)
    {
        problemSpace = new List<List<string>>();
        currentLevel = level;
        int numOfProblem = 5;
        for (int i = 0; i < numOfProblem; i++)
        {
            problemSpace.Add(getRandProb());
        }

        return problemSpace;
    }

    public List<string> getRandProb()
    {
        List<string> singProb = new List<string>();
        string operatorString;
        int const1, const2, const3, const4;

        int max = 0;
        int min = 0;
        int opMax = 0;
        int opMin = 0;
        if (currentLevel == 1 || currentLevel == 3)
        {
            min = 2;
            max = 11;
        } else
        {
            min = 10;
            max = 100;
        }

        if (currentLevel == 1 || currentLevel == 2)
        {
            opMax = 3;
        } else
        {
            opMin = 3;
            opMax = 4;
        }


        // Selecting random answer, constants and operator
        //Random rnd = new Random();
        int ans = Random.Range(min, max);
        int const5 = Random.Range(min, max);
        int const6 = Random.Range(min, max);
        var operation = Random.Range(opMin, opMax);
        // var operation = 3;

        singProb.Add(ans.ToString());

        switch (operation)
        {
            case 1:
                operatorString = "+";
                singProb.Add(operatorString);
                const1 = Random.Range(1, ans);
                const2 = ans - const1;
                const3 = Random.Range(1, ans);
                while (const3 == const1)
                {
                    const3 = Random.Range(1, ans);
                }
                const4 = ans - const3;
                break;
            case 2:
                operatorString = "-";
                singProb.Add(operatorString);
                const1 = Random.Range(1, ans);
                const2 = ans + const1;
                const3 = Random.Range(1, ans);
                while ( const3 == const1)
                {
                    const3 = Random.Range(2, ans);
                }
                const4 = ans + const3;
                break;
            case 3:
                operatorString = "*";
                singProb.Add(operatorString);
                do
                {
                    const1 = Random.Range(1, ans);
                } while (ans % const1 != 0);
                const2 = ans / const1;
                do
                {
                    const3 = Random.Range(1, ans);
                    if (const3 == const1 || const3 == const2)
                    {
                        break;
                    }
                } while (ans % const3 != 0);
                const4 = ans / const3;
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
        singProb.Add(const6.ToString());

        return singProb;

    }
}
