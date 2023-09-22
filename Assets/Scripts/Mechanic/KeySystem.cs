using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySystem : MonoBehaviour
{
    private bool isPlayerNear;

    // Key
    public bool Key1;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Key")){
            isPlayerNear = true; 
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Key")){
            isPlayerNear = false; 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E)) {
                Key1 = true;
                Destroy(GameObject.FindWithTag("Key"));
            }
        }
    }
}
