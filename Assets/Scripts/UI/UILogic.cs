using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILogic : MonoBehaviour
{
    public GameObject panelPause;
    public GameObject panelGameOver;
    public GameObject displayHealth;
    public GameObject displayNotif;
    HealthSystem healthSystem;

    private void Update()
    {
        PanelPause();
    }
    public void PanelPause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            panelPause.SetActive(true);
            displayHealth.SetActive(false);
            displayNotif.SetActive(false);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ResumeGame()
    {
        panelPause.SetActive(false);
        displayHealth.SetActive(true);
        displayNotif.SetActive(true);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("");
    }

    public void PanelGameOver()
    {
        if(healthSystem.health == 0)
        {
            panelGameOver.SetActive(true);
        }
    }
}
