using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Data;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject n1;
    public GameObject n2;
    public GameObject n3;
    public GameObject n4;
    public GameObject n5;
    public GameObject n6;
    public GameObject n7;
    public GameObject n8;
    public GameObject n9;
    public GameObject n10;

    public GameObject o1;
    public GameObject o2;
    public GameObject o3;
    public GameObject o4;
    public GameObject o5;
    public GameObject o6;

    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;
    public GameObject s5;
    public GameObject s6;
    public GameObject s7;
    public GameObject s8;
    public GameObject s9;
    public GameObject s10;
    public GameObject s11;
    public GameObject s12;
    public GameObject s13;
    public GameObject s14;
    public GameObject s15;
    public GameObject s16;
    public GameObject s17;

    List<GameObject> numbers = new List<GameObject>();
    List<GameObject> operators = new List<GameObject>();
    List<GameObject> slots = new List<GameObject>();
    string inputs = "";

    public Scrollbar energyBar;
    public Slider goalBar;
    float barMax;
    public GameObject goalText;
    public GameObject maxText;

    int slotIndex = 0;
    int numOfNumbers = 0;
    int numOfOperators = 0;

    public GameObject winUI;
    public GameObject failUI;

    //Dictionary<int, List<string>> problemSpace = new Dictionary<int, List<string>>();
    List<string> problemSpace = new List<string>();

    string[] operatorList = { "+", "-", "*", "/" };

    int answer;
    int progress = 0;

    public GameObject numberEffect;
    public GameObject operatorEffect;

    float numEffectTime;
    float opEffectTime;

    float numEffectMaximum = 2000f;
    float opEffectMaximum = 2000f;

    void Start()
    {
        numEffectTime = numEffectMaximum;
        opEffectTime = opEffectMaximum;

        numbers.Add(n1);
        numbers.Add(n2);
        numbers.Add(n3);
        numbers.Add(n4);
        numbers.Add(n5);
        numbers.Add(n6);
        numbers.Add(n7);
        numbers.Add(n8);
        numbers.Add(n9);
        numbers.Add(n10);

        operators.Add(o1);
        operators.Add(o2);
        operators.Add(o3);
        operators.Add(o4);
        operators.Add(o5);
        operators.Add(o6);

        slots.Add(s1);
        slots.Add(s2);
        slots.Add(s3);
        slots.Add(s4);
        slots.Add(s5);
        slots.Add(s6);
        slots.Add(s7);
        slots.Add(s8);
        slots.Add(s9);
        slots.Add(s10);
        slots.Add(s11);
        slots.Add(s12);
        slots.Add(s13);
        slots.Add(s14);
        slots.Add(s15);
        slots.Add(s16);
        slots.Add(s17);

        TestingProblemSpace();
        SpawnPotions();

    }

    // Update is called once per frame
    void Update()
    {
        if (progress == answer)
        {
            PauseGame();
            Win();
        }

        if (progress < 0 || progress > barMax || numOfNumbers <= 0)
        {
            PauseGame();
            EndGame();
        }
        
        if (numEffectTime < numEffectMaximum)
        {
            numEffectTime += Time.timeScale;
        } else
        {
            numberEffect.SetActive(false);
        }

        if (opEffectTime < opEffectMaximum)
        {
            opEffectTime += Time.timeScale;
        } else
        {
            operatorEffect.SetActive(false);
        }
        
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    void Win()
    {
        numberEffect.SetActive(false);
        operatorEffect.SetActive(false);
        winUI.SetActive(true);
    }

    void EndGame()
    {
        numberEffect.SetActive(false);
        operatorEffect.SetActive(false);
        failUI.SetActive(true);
    }

    void SpawnPotions()
    {
        ResumeGame();

        numEffectTime = numEffectMaximum;
        opEffectTime = opEffectMaximum;

        winUI.SetActive(false);
        failUI.SetActive(false);

        int numberIndex = 0;
        int operatorIndex = 0;

        answer = int.Parse(problemSpace[0]);
        barMax = 1.4f * answer;
        goalText.GetComponent<Text>().text = answer.ToString();
        goalBar.value = answer / barMax;
        maxText.GetComponent<Text>().text = "Max: " + barMax.ToString();

        for (int i = 1; i < problemSpace.Count; i++)
        {
            if (Array.IndexOf(operatorList, problemSpace[i]) == -1)
            {
                numbers[numberIndex].GetComponent<Dragger>().SetValue(problemSpace[i]);
                numberIndex++;
            }
            else
            {
                operators[operatorIndex].GetComponent<Dragger>().SetValue(problemSpace[i]);
                operatorIndex++;
            }
        }

        for (int j = numberIndex; j < numbers.Count; j++)
        {
            numbers[j].SetActive(false);
        }

        for (int k = operatorIndex; k < operators.Count; k++)
        {
            operators[k].SetActive(false);
        }

        numOfNumbers = numberIndex - 1;
        numOfOperators = operatorIndex - 1;
    }

    public void ResetGame()
    {
        progress = 0;
        slotIndex = 0;
        SpawnPotions();
        foreach (GameObject num in numbers)
        {
            num.SetActive(true);
        }
        foreach (GameObject op in operators)
        {
            op.SetActive(true);
        }
        foreach (GameObject text in slots)
        {
            text.GetComponent<TextMeshProUGUI>().SetText("");
        }
        inputs = "";
        energyBar.size = 0f;
        SpawnPotions();
    }

    void TestingProblemSpace()
    {
        problemSpace.Add("10");
        problemSpace.Add("2");
        problemSpace.Add("6");
        problemSpace.Add("4");
        problemSpace.Add("8");
        problemSpace.Add("5");
        problemSpace.Add("5");
        problemSpace.Add("+");
        problemSpace.Add("+");
        problemSpace.Add("-");
    }

    public void AddPotionToSlot(string value)
    {
        inputs += value;
        slots[inputs.Length - 1].GetComponent<TextMeshProUGUI>().SetText(value);
        
        if (Array.IndexOf(operatorList, value) == -1)
        {
            evaluate();
            numEffectTime = 0f;
            numberEffect.SetActive(true);
        } else
        {
            opEffectTime = 0f;
            operatorEffect.SetActive(true);
        }
        float portion = progress / barMax;
        energyBar.size = portion;

    }

    void evaluate()
    {
        DataTable dt = new DataTable();
        progress = (int)dt.Compute(inputs, "");
    }

    public bool validInput(string value)
    {
        if (inputs.Length == 0 && Array.IndexOf(operatorList, value) > -1)
        {
            return true;
        }
        else if (Array.IndexOf(operatorList, value) > -1 && Array.IndexOf(operatorList, inputs.Substring(inputs.Length - 1)) > -1)
        {
            return false;
        } else
        {
            return true;
        }
    }
}
