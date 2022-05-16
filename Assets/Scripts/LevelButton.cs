using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    // Start is called before the first frame update
    public int level;
    public GameObject controller;
    bool[] status;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        status = controller.GetComponent<GameController>().GetLevelStatus();
        if (level != 1)
        {
            if (status[level - 2])
            {
                GetComponent<Button>().interactable = true;
            } else
            {
                GetComponent<Button>().interactable = false;
            }
        }
    }
}
