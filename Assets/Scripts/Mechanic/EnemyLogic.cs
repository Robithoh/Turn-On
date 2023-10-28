using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public GameObject jumpScarePanel;
    public AudioSource audioSource;
   
    void Start()
    {
        jumpScarePanel.SetActive(false);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        jumpScarePanel.SetActive(true);
    //        audioSource.Play();
    //        StartCoroutine(disablePanel());
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            jumpScarePanel.SetActive(true);
            audioSource.Play();
            StartCoroutine(disablePanel());
        }
        else
        {
            jumpScarePanel.SetActive(false);
        }
    }

    IEnumerator disablePanel()
    {
        yield return new WaitForSeconds(2);
        jumpScarePanel.SetActive(false);
        Destroy(gameObject);
    }
}
