using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    public void StartButton(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
