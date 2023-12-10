using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int health; // Jumlah nyawa awal
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject panel_gameover;

    void Update() {
        for (int i = 0; i < hearts.Length; i++) {
            if (i < health) {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Gantilah "Enemy" dengan tag yang sesuai untuk musuh Anda
        {
            TakeDamage(1); // Panggil fungsi TakeDamage dan kurangi 1 nyawa

            // Hancurkan musuh setelah menabrak pemain
            //Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            StartCoroutine(disablePanel());
        }
    }

    IEnumerator disablePanel()
    {
        yield return new WaitForSeconds(2);
        panel_gameover.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}