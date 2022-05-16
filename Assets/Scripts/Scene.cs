using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("MathInterface");
    }

    public void Instruction()
    {
        SceneManager.LoadScene("HowToPlay1");
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("TitleMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
