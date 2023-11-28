using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenDoor : MonoBehaviour
{
    [SerializeField] private Animator myHiddenDoor = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myHiddenDoor.Play("DoorSlide");
        }
    }
}
