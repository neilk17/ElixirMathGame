using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currentNode;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CurrentProblem()
    {
        currentNode.SetActive(true);
    }

    public void NotCurrentProblem()
    {
        currentNode.SetActive(false);
    }
}
