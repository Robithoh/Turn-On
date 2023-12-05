using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampMechanic : MonoBehaviour
{
    public GameObject lamp;
    //public GameObject floatText;
    public GameObject ghost;

    private bool isPlayerNear;

    // Start is called before the first frame update
    void Start()
    {
        lamp.SetActive(false);
        //floatText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerNear = true;
            //floatText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerNear = false; 
            //floatText.SetActive(false);
        }
    }

    void Update()
    {
        if(isPlayerNear)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                //ToggleLamp();
                lamp.SetActive(true);
                Destroy(ghost);
            }
        }
    }
}
