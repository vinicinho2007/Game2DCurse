using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Config.Movement e Jump")]
    public BoxCollider2D boxCollider2D;
    public Rigidbody2D rig2D;
    public float speed, speedRun, forceJump;
    public Vector2 friction;
    private float _speedCurrent;

    [Header("Animation Jump")]
    public Vector2 scaleJump;
    public float animDuration;

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
            rig2D.velocity += friction;
        }
        else if (rig2D.velocity.x < 0)
        {
            rig2D.velocity -= friction;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig2D.velocity = transform.up * forceJump;
            AnimationJumpTo();
        }
    }

    private void AnimationJumpTo()
    {
        transform.localScale = Vector2.one;
        DOTween.Kill(transform);
        transform.DOScaleX(scaleJump.x, animDuration).SetLoops(2,LoopType.Yoyo).SetEase(Ease.OutBack);
        transform.DOScaleY(scaleJump.y, animDuration).SetLoops(2,LoopType.Yoyo).SetEase(Ease.OutBack);
    }
}