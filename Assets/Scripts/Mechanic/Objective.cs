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
    public LampMechanic lampMechanic; // Referensi ke skrip LampMechanic
    private bool canIncrement = true;
    private bool canDecrement = true;
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
        if (lampMechanic.lampCount == 0 && canIncrement)
        {
            numOfStars = Mathf.Min(numOfStars + 1, 2);
            canIncrement = false;
            canDecrement = true;
        }
        else if (hearts == 2 && canIncrement)
        {
            numOfStars = Mathf.Min(numOfStars + 1, 2);
            canIncrement = false;
            canDecrement = true;
        }
        else if (!canDecrement)
        {
            canIncrement = true;
        }
    }
}