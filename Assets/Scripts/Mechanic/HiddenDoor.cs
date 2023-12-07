using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenDoor : MonoBehaviour
{
    [SerializeField] private Animator myHiddenDoor = null;
    public Text keyNotification;
    private bool isPlayerNear;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        myHiddenDoor.Play("DoorSlide");
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            keyNotification.text = "Press E to open";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            keyNotification.text = "";
        }
    }

    void Update()
    {
        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                myHiddenDoor.Play("DoorSlide");
            }
        }
    }
}
