using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    int currentLevel = 1;
    List<string> singProb = new List<string>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<string> getProblemSpace(int level)
    {
        currentLevel = level;
        singProb = new List<string>();
        
        if (currentLevel == 1)
        {
            return GetRandProb();
        } else if (currentLevel == 2)
        {
            return GetRandProbAd();
        } else
        {
            int ran = Random.Range(1, 3);
            if (ran == 1)
            {
                return GetRandProb();
            } else
            {
                return GetRandProbAd();
            }
        }
    }

    public List<string> GetRandProbAd()
    {
        int op = Random.Range(1, 3);
        if (op == 1)
        {
            return getMultProb();
        } else
        {
            return getDivPro();
        }
    }

    public List<string> GetRandProb()
    {
        singProb = new List<string>();
        string operatorString;
        int const1, const2, const3, const4;
        int ans = Random.Range(2, 11);
        int const5 = Random.Range(1, 10);
        while (const5 == ans)
        {
            const5 = Random.Range(1, 10);
        }
        int const6 = Random.Range(1, 10);
        while (const6 == ans)
        {
            const6 = Random.Range(1, 10);
        }
        var operation = Random.Range(1, 3);
        // var operation = 3;

        singProb.Add(ans.ToString());

        switch (operation)
        {
            case 1:
                operatorString = "-";
                singProb.Add(operatorString);
                operatorString = "+";
                singProb.Add(operatorString);
                operatorString = "-";
                singProb.Add(operatorString);
                operatorString = "+";
                singProb.Add(operatorString);
                const1 = Random.Range(1, ans);
                const2 = ans - const1;
                const3 = Random.Range(1, ans);
                if (ans > 4)
                {
                    while (const3 == const1)
                        {
                            const3 = Random.Range(1, ans);
                        }
                }
                const4 = ans - const3;
                break;
            case 2:
                operatorString = "-";
                singProb.Add(operatorString);
                operatorString = "+";
                singProb.Add(operatorString);
                operatorString = "-";
                singProb.Add(operatorString);
                operatorString = "+";
                singProb.Add(operatorString);
                const1 = Random.Range(1, ans);
                const2 = ans + const1;
                const3 = Random.Range(1, ans);
                if (ans > 2)
                {
                    while (const3 == const1)
                    {
                        const3 = Random.Range(1, ans);
                    }
                }
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
        singProb.Add(const6.ToString());

        Shuffle(singProb);

        return singProb;

    }

    public List<string> getMultProb()
    {
        singProb = new List<string>();

        int const1 = Random.Range(2, 10);
        int const2 = Random.Range(2, 10);
        int ans = const1 * const2;

        int ans2 = 0;
        int const3 = 0;
        int const4 = 0;
        while (ans2 != ans)
        {
            const3 = Random.Range(2, 10);
            const4 = Random.Range(2, 10);
            ans2 = const3 * const4;
        }

        int const5 = Random.Range(2, 10);
        int const6 = Random.Range(2, 10);

        singProb.Add(ans.ToString());
        singProb.Add("*");
        singProb.Add("/");
        singProb.Add("*");
        singProb.Add("/");
        singProb.Add(const1.ToString());
        singProb.Add(const2.ToString());
        singProb.Add(const3.ToString());
        singProb.Add(const4.ToString());
        singProb.Add(const5.ToString());
        singProb.Add(const6.ToString());

        Shuffle(singProb);

        return singProb;
    }

    public List<string> getDivPro()
    {
        singProb = new List<string>();

        int ans = Random.Range(2, 10);
        int const1 = Random.Range(2, 10);
        int const2 = const1 * ans;
        int const3 = Random.Range(2, 10);
        int const4 = const3 * ans;

        int const5 = Random.Range(2, 10);
        int const6 = Random.Range(2, 10);

        singProb.Add(ans.ToString());
        singProb.Add("*");
        singProb.Add("/");
        singProb.Add("*");
        singProb.Add("/");
        singProb.Add(const1.ToString());
        singProb.Add(const2.ToString());
        singProb.Add(const3.ToString());
        singProb.Add(const4.ToString());
        singProb.Add(const5.ToString());
        singProb.Add(const6.ToString());

        Shuffle(singProb);

        return singProb;
    }


    void Shuffle<T>(List<T> inputList)
    {
        for (int i = 1; i < inputList.Count; i++)
        {
            T temp = inputList[i];
            int rand = Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;
        }
    }
}
