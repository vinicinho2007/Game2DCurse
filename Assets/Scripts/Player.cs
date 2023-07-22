using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D rig2D;
    public float speed, speedRun, forceJump;
    private float _speedCurrent;

    private void FixedUpdate()
    {
        Jump();
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speedCurrent = speedRun;
        }
        else
        {
            _speedCurrent = speed;
;        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rig2D.velocity = new Vector2(_speedCurrent, rig2D.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rig2D.velocity = new Vector2(-_speedCurrent, rig2D.velocity.y);
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rig2D.velocity = Vector2.up * forceJump;
        }
    }
}