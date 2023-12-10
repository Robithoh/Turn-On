using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trigger_Panel : MonoBehaviour
{
    public GameObject panel_done;
    public GameObject panel_tambahan;


    void Start()
    {
        panel_done.SetActive(false);
        panel_tambahan.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            panel_done.SetActive(true);
            panel_tambahan.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
