using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    private float Rspeed = 75f;

    private void Update()
    {
        transform.Rotate(Vector3.up, Rspeed * Time.deltaTime);
    }
    public enum KeyType
    {
        BathroomKey,
        BedroomKey,
        PersonalroomKey,
        LaundryroomKey,
        KitchenKey
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }
}
