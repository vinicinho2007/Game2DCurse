using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D rig2D;
    public float speed;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            //rig2D.velocity = new Vector2(speed,transform.position.y);
            transform.Translate(speed*Time.deltaTime,0,0);
        }
        if (h < 0)
        {
            //rig2D.velocity = new Vector2(-speed,transform.position.y);
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
    }
}