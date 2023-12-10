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

    public GameObject panelMainMenu;
    public GameObject panelCredit;
    public GameObject panelSetting;

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

    public void Home()
    {
        panelMainMenu.SetActive(true);
        panelSetting.SetActive(false);
        panelCredit.SetActive(false);
    }

    public void Setting()
    {
        panelSetting.SetActive(true);
        panelMainMenu.SetActive(false);
    }

    public void Credits()
    {
        panelCredit.SetActive(true);
        panelMainMenu.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("PlayScene");
    }

}
