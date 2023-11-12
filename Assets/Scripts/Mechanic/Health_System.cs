using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int health = 2; // Jumlah nyawa awal
    public int numOfHearts;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Gantilah "Enemy" dengan tag yang sesuai untuk musuh Anda
        {
            TakeDamage(1); // Panggil fungsi TakeDamage dan kurangi 1 nyawa

            // Hancurkan musuh setelah menabrak pemain
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // Player mati, tambahkan kode sesuai kebutuhan
        }
    }
}