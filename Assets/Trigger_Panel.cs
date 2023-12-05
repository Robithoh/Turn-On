using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Panel : MonoBehaviour
{
    public GameObject panel_done;

    void Start()
    {
        panel_done.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            panel_done.SetActive(true);
        }
    }
}
