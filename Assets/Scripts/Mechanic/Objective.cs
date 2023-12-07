using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    public HealthSystem HealthSystem;
    public int numOfStars;
    public Image[] Stars;
    public Sprite fullStar;
    public Sprite emptyStar;
    //public LampMechanic lampMechanic; // Referensi ke skrip LampMechanic
    public bool isPlayerNear = false;
    // Update is called once per frame
    void Update()
    {
        int hearts = HealthSystem.numOfHearts;

        for (int i = 0; i < Stars.Length; i++)
        {
            if (i < numOfStars)
            {
                Stars[i].sprite = fullStar;
                Stars[i].enabled = true;
            }
            else
            {
                Stars[i].sprite = emptyStar;
                Stars[i].enabled = false;
            }
        }

        // Ubah kondisi untuk mengatur numOfStars
        if (hearts == 2)
        {
            numOfStars = 3;
        }
        else if (CharacterMovement.instance.lampCount == 0)
        {
            numOfStars = 2;
        }
        else if (isPlayerNear == true)
        { 
            numOfStars = 1;
        }
        else
        {
            numOfStars = 0;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("End")){
            isPlayerNear = true;
        }
    }
}