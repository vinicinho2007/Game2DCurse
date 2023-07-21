using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public float animDuration;
    public Vector3 scale;

    void Update()
    {
        BigPlayer();
    }

    private void BigPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float scaleBack = transform.localScale.x;
            transform.localScale = scale;
            transform.DOScale(scaleBack, animDuration).From();
        }
    }
}