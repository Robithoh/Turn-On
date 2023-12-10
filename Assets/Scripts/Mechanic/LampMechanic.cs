using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampMechanic : MonoBehaviour
{
    public GameObject lamp;
    public List<GameObject> enemy;

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
                for (int letterIndex = 0; letterIndex < enemy.Count; letterIndex++)
                {
                    Destroy(enemy[letterIndex]) ;
                    CharacterMovement.instance.lampCount--;
                }
                    
            }
        }
    }
}