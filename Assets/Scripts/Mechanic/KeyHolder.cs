using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;
    public Text keyNotification;
    bool isPlayerNear = false;
    private KeyDoor currentKeyDoor; // Menyimpan referensi ke pintu yang sedang berdekatan

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
        isPlayerNear = true;
        Key key = other.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        KeyDoor keyDoor = other.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            currentKeyDoor = keyDoor; // Simpan referensi ke pintu yang berdekatan
            if (ContainsKey(keyDoor.GetKeyType()))
            {
                keyDoor.doorInfoFalse();
                Destroy(other);
            }
            else
            {
                keyDoor.doorInfoTrue();
            }
        }
    }

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            CheckDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerNear = false;
        KeyDoor keyDoor = other.GetComponent<KeyDoor>();
        keyDoor.doorInfoFalse();
        currentKeyDoor = null; // Atur kembali referensi ke pintu menjadi null
    }

    void HideKeyInfo()
    {
        keyNotification.text = "";
    }

    void CheckDoor()
    {
        if (currentKeyDoor != null && !ContainsKey(currentKeyDoor.GetKeyType()))
        {
            // Jika pintu berdekatan dan pemain tidak memiliki kunci yang sesuai, tidak lakukan apa-apa
            return;
        }

        if (currentKeyDoor != null)
        {
            currentKeyDoor.ToggleDoor(); // Panggil metode untuk membuka pintu
            RemoveKey(currentKeyDoor.GetKeyType()); // Hapus kunci dari daftar pemain
        }
    }
}