using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampMechanic : MonoBehaviour
{
    public GameObject lamp;
    //public GameObject enemyDumm;

    private bool isPlayerNear;

    
    // Start is called before the first frame update
    void Start()
    {
        lamp.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void Update()
    {
        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                lamp.SetActive(true);
                //Destroy(enemyDumm);
                CharacterMovement.instance.lampCount--;
            }
        }
    }
}