using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampMechanic : MonoBehaviour
{
    public GameObject lamp1;
    public GameObject floatText;

    private bool isPlayerNear, isLampOn;

    // Start is called before the first frame update
    void Start()
    {
        lamp1.GetComponent<Light>().enabled = false;
        floatText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            isPlayerNear = true;
            floatText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerNear = false; 
            floatText.SetActive(false);
        }
    }

    private void ToggleLamp()
    {
        if(isLampOn)
        {
            lamp1.GetComponent<Light>().enabled = true;
            isLampOn = false;
        }else
        {
            lamp1.GetComponent<Light>().enabled = false;
            isLampOn = true;
        }
    }

    void Update()
    {
        if(isPlayerNear)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                ToggleLamp();
            }
        }
    }
}