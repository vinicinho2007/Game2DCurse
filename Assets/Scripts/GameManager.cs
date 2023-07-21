using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instante;
    public GameObject prefPlayer;
    public Transform position;
    public float animDuration;

    private void Start()
    {
        if(instante == null)
        {
            instante = this;
        }
        else
        {
            Destroy(gameObject);
        }
        StartPlayer();
    }

    private void StartPlayer()
    {
        GameObject obj = Instantiate(prefPlayer, position);
        obj.transform.DOScale(0, animDuration).From();
    }
}