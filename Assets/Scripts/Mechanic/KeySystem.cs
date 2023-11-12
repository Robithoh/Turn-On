using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeySystem : MonoBehaviour
{
    private bool isPlayerNear;
    public Text keyNotification;

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

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E)) {
                Key1 = true;
                ShowKeyInfo();
                Destroy(GameObject.FindWithTag("Key"));
            }
        }
    }

    void ShowKeyInfo()
    {
        keyNotification.text = "Key Collected";

        Invoke("HideKeyInfo", 3f);
    }

    void HideKeyInfo()
    {
        keyNotification.text = "";
    }
}
