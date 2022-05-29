using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    public Image fill;
    public Text timerText;

    int duration;
    int remainingDuration;

    public GameObject controller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Being(int sec)
    {
        remainingDuration = 0;
        duration = sec;
        remainingDuration = sec;
        IEnumerator timer = UpdateTimer();
        StartCoroutine(timer);
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            timerText.text = $"{remainingDuration / 60:00} : {remainingDuration % 60:00}";
            fill.fillAmount = Mathf.InverseLerp(0, duration, remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        onEnd();
    }

    private void onEnd()
    {
        controller.GetComponent<GameController>().EndGame();
    }

    public void End()
    {
        StopAllCoroutines();
    }

}
