using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obj_Anim : MonoBehaviour
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
    public bool isPlayerNear = false;

    private string mSpritesPath;

    void Start()
    {
        nImage = GetComponent<Image>();
        enabled = false;
        Obj_Cond();
        LoadSpriteSheet();
    }

    void Obj_Cond()
    {
        int hearts = HealthSystem.health;

        // Ubah kondisi untuk mengatur numOfStars
        if (hearts == 2 && CharacterMovement.instance.lampCount == 0)
        {
            mSpritesPath = "bintang/bintang3";
        }
        else if (CharacterMovement.instance.lampCount == 0 && hearts == 1)
        {
            Debug.Log("Lampu mati");
            mSpritesPath = "bintang/bintang2";
        }
        else
        { 
            Debug.Log("Nyawa habis");
            mSpritesPath = "bintang/bintang1";
        }

        Debug.Log(mSpritesPath);
    }

    void LoadSpriteSheet()
    {
        mSprites = Resources.LoadAll<Sprite>(mSpritesPath);

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

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("End")){
            isPlayerNear = true;
        }
    }
}
