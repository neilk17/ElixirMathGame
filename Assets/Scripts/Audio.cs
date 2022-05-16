using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip click;
    public AudioSource AS;
    public AudioClip potion;
    public AudioClip win;
    public AudioClip fail;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClick()
    {
        AS.clip = click;
        AS.Play();
    }

    public void AddPotion()
    {
        AS.clip = potion;
        AS.Play();
    }

    public void Win()
    {
        AS.clip = win;
        AS.Play();
    }

    public void Lose()
    {
        AS.clip = fail;
        AS.Play();
    }
}
