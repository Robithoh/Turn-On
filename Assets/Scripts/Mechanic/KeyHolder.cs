using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;
    public Text keyNotification;
    bool isPlayerNear = false;

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Added Key: " + keyType);
        keyNotification.text = "Added " + keyType.ToString();
        Invoke("HideKeyInfo", 3f);
        keyList.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter(Collider other)
    {
        //isPlayerNear = true;
        Key key = other.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        KeyDoor keyDoor = other.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            if (ContainsKey(keyDoor.GetKeyType()))
            {
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.ToggleDoor();
                keyDoor.doorInfoFalse();
                Destroy(other);
            }
            else
            {
                keyDoor.doorInfoTrue();
            }
        }
    }

    //private void Update()
    //{
    //    if(isPlayerNear)
    //    {
    //        if(Input.GetKeyDown(KeyCode.E))
    //        {
    //            checkKey();
    //            checkDoor();
    //        }
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        isPlayerNear = false;
        KeyDoor keyDoor = other.GetComponent<KeyDoor>();
        keyDoor.doorInfoFalse();
    }

    void HideKeyInfo()
    {
        keyNotification.text = "";
    }
}
