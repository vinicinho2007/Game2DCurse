using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satelite : MonoBehaviour
{
    [Header("Animação")]
    public Animator anim;
    public string flyAnimBool;
    public float tempOurMove;

    [Header("Movimentação")]
    public float speed;
    public float posXR, posXL;
    private bool moveRight, movement;

    private void Update()
    {
        if (!movement)
        {
            Move();
        }
    }

    private void Move()
    {
        anim.SetBool(flyAnimBool, true);

        if (!moveRight)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
        else
        {
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
        }

        if (transform.position.x >= posXR || transform.position.x <= posXL)
        {
            CheckMove();
        }
    }

    private void CheckMove()
    {
        if (transform.position.x >= posXR)
        {
            moveRight = true;
        }
        if (transform.position.x <= posXL)
        {
            moveRight = false;
        }
        StartCoroutine(AnimCoroutine());
    }

    private IEnumerator AnimCoroutine()
    {
        anim.SetBool(flyAnimBool, false);
        movement = true;
        yield return new WaitForSeconds(tempOurMove);
        movement = false;
    }
}