using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private Key.KeyType keyType;

    public Key.KeyType GetKeyType() 
    { 
        return keyType; 
    }

    public void OpenDoor()
    {
        ToggleDoor();
    }

    private void ToggleDoor()
    {
        myDoor.Play("DoorOpen", 0, 0.0f);      
    }
}
