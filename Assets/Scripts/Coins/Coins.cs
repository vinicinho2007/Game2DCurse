using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public ParticleSystem particleSystemCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            particleSystemCoin.transform.SetParent(null);
            particleSystemCoin.Play();
            GameManager.instante.coinsSO.value++;
            Destroy(gameObject);
        }
    }
}