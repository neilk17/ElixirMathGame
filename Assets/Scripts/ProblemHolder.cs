using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemHolder : MonoBehaviour
{
    List<string> problemSpace = new List<string>();
    public GameObject control;
    List<List<string>> problems = new List<List<string>>();

    // Start is called before the first frame update
    void Start()
    {
        problemSpace.Add("10");
        problemSpace.Add("10");
        problems.Add(problemSpace);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
