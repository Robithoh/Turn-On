using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.ProBuilder.Shapes;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private Key.KeyType keyType;
    public Text keyNotification;

    public Key.KeyType GetKeyType() 
    { 
        return keyType; 
    }

    public void doorInfoTrue()
    {
        keyNotification.text = keyType.ToString() + " needed";
    }

    public void doorReady()
    {
        keyNotification.text = "Press E to open";
    }

    public void doorInfoFalse()
    {
        keyNotification.text = "";
    }

    public void ToggleDoor()
    {
        OpenDoor();
    }

    public void OpenDoor()
    {
        myDoor.Play("DoorOpen", 0, 0.0f);
    }
}
