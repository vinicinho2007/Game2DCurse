using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D rig2D;
    public float speed, forceJump;

    private void FixedUpdate()
    {
        Jump();
        Move();
    }

    private void Move()
    {
        var h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            rig2D.velocity = new Vector2(speed,rig2D.velocity.y);
        }
        if (h < 0)
        {
            rig2D.velocity = new Vector2(-speed,rig2D.velocity.y);
        }

        if (rig2D.velocity.x > 0)
        {
            rig2D.velocity += new Vector2(-.1f, 0);
        }
        else if (rig2D.velocity.x < 0)
        {
            rig2D.velocity -= new Vector2(-.1f, 0);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig2D.AddForce(transform.up * forceJump,ForceMode2D.Impulse);
        }
    }
}