using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    public KeySystem keySystem; // Ini adalah variabel publik yang bisa Anda atur di inspector
    public TextMeshProUGUI text; // Komponen TextMeshProUGUI
    public int Key_Amount; // Jumlah kunci yang dimiliki
    private bool keyTaken = false; // Apakah kunci sudah diambil?
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>(); // Dapatkan komponen TextMeshPro dari objek ini
        text.text = Key_Amount.ToString(); // Ubah nilai number menjadi string dan tetapkan ke teks;
    }

    void Update()
    {
        if (keySystem.Key1 && !keyTaken)
        {
            Key_Amount++;
            text.text = Key_Amount.ToString();
            keyTaken = true; // Set keyTaken menjadi true ketika kunci diambil
        }
        else if (!keySystem.Key1 && keyTaken)
        {
            keyTaken = false; // Set keyTaken menjadi false ketika kunci tidak tersedia
        }
    }

}
