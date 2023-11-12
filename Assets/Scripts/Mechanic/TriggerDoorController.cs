using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    // [SerializeField] private bool openTrigger = false;
    // [SerializeField] private bool closeTrigger = false;
    private bool isPlayerNear, isDoorOpen = false;

    private KeySystem keys;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            isPlayerNear = true; 
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")){
            isPlayerNear = false; 
        }
    }

    private void Start() {
        keys = FindObjectOfType<KeySystem>();
    }

    // void Update(){
    //     if(isPlayerNear){
    //         if(Input.GetKeyDown(KeyCode.E)){
    //             if(openTrigger){
    //                 myDoor.Play("DoorOpen", 0, 0.0f);
    //             // gameObject.SetActive(false);
    //             }else if(closeTrigger){
    //                 myDoor.Play("DoorClose",0,0.0f);
    //             // gameObject.SetActive(false);
    //             }
    //         }
    //     }
    // }

    private void ToggleDoor(){
        if(isDoorOpen){
            myDoor.Play("DoorClose",0,0.0f);
            isDoorOpen = false;
        }else{
            myDoor.Play("DoorOpen",0,0.0f);
            isDoorOpen = true;
        }
    }

    void Update(){
        if(isPlayerNear){
            if(Input.GetKeyDown(KeyCode.E) && keys.Key1 == true)  
            {
                ToggleDoor();
            }
        }
    }
}
