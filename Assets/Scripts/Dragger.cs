using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Dragger : MonoBehaviour
{
    Vector3 startingLocation;
    private bool inRange = false;
    Vector3 desLocation;

    public GameObject controller;

    public TextMeshPro text;

    public string value = "";

    private void Start()
    {
        startingLocation = transform.position;
    }

    public void SetValue(string input)
    {
        value = input;
        text.SetText(value);
    }

    public string GetValue()
    {
        return value;
    }

    Vector3 GetMousePos()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseUp()
    {
        if (inRange)
        {
            if (controller.GetComponent<GameController>().validInput(value))
            {
                transform.position = desLocation;
                AddPotion();
                transform.gameObject.SetActive(false);
            } else
            {
                transform.position = startingLocation;
            }
            
            inRange = false;
        } else
        {
            transform.position = startingLocation;
        }
        
    }

    void AddPotion()
    {
        controller.GetComponent<GameController>().AddPotionToSlot(value);
    }

    void OnMouseDrag()
    {
        transform.position = GetMousePos(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Des"))
        {
            inRange = true;
            desLocation = startingLocation;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
        desLocation = startingLocation;
    }

}
