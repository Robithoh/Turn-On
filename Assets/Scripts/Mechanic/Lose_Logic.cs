using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose_Logic : MonoBehaviour
{
    public float _Speed;
    public float _FrameRate = 30;
    private Image nImage = null;
    private Sprite[] mSprites = null;
    private float nTimePerFrame = 0f;
    private float nElapsedTime = 0f;
    private int nCurrentFrame = 0;

    // Logika untuk mengatur bintang
    public HealthSystem HealthSystem; // Referensi ke skrip LampMechanic

    private string mSpritesPath;

    void Start()
    {
        nImage = GetComponent<Image>();
        enabled = false;
        LoadSpriteSheet();
    }

    void LoadSpriteSheet()
    {
        mSprites = Resources.LoadAll<Sprite>("lose/lose");

        if (mSprites != null && mSprites.Length > 0)
        {
            nTimePerFrame = 0.01f / _FrameRate;
            enabled = true;
        }
        else
        {
            Debug.LogError("Failed to load sprites");
        }
    }

    public void Play()
    {
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        nElapsedTime += Time.deltaTime * _Speed;
        if (nElapsedTime >= nTimePerFrame)
        {
            ++nCurrentFrame;
            SetSprites();
            if (nCurrentFrame >= mSprites.Length)
            {
                enabled = false;
            }
        }
        
    }

    private void SetSprites()
    {
        if (nCurrentFrame >= 0 && nCurrentFrame < mSprites.Length)
        {
            nImage.sprite = mSprites[nCurrentFrame];
        }
    }
}
