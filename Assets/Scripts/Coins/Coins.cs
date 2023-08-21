using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public ParticleSystem particleSystemCoin;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.Find("SFX_CoinCollet").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (audioSource != null) { audioSource.Play(); }
            particleSystemCoin.transform.SetParent(null);
            particleSystemCoin.Play();
            GameManager.instante.coinsSO.value++;
            Destroy(gameObject);
        }
    }
}