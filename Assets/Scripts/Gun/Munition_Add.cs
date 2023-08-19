using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Munition_Add : MonoBehaviour
{
    public SOFloat munition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.FindObjectOfType<Gun>()._maxMunition += munition.value;
            Destroy(gameObject);
        }
    }
}