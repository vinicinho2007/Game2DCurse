using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Outros Scripts")]
    private GameManager gameManager;
    private bool kill;

    [Header("Config.Movement e Jump")]
    public Rigidbody2D rig2D;
    public float speed, speedRun, forceJump;
    public Vector2 friction;
    private float _speedCurrent;

    [Header("Animation")]
    public Animator anim;
    public string moveAnim, jumpAnim, jumpTriggerGroundAnim, animKill, nameRun, nameSpeedRun;
    public float tempDelayKill;
    private bool moveAnimBool;
    private float posY;

    [Header("Vida")]
    public float healt;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        if (!kill)
        {
            Jump();
            Move();
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speedCurrent = speedRun;
            moveAnim = nameSpeedRun;
        }
        else
        {
            _speedCurrent = speed;
            moveAnim = nameRun;
        }

        if (Input.GetAxisRaw("Horizontal") != 0 && !moveAnimBool)
        {
            anim.SetBool(moveAnim, true);
        }
        else
        {
            anim.SetBool(moveAnim, false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rig2D.velocity = new Vector2(_speedCurrent, rig2D.velocity.y);
            transform.DORotate(new Vector3(0, 0, 0), 0.1f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rig2D.velocity = new Vector2(-_speedCurrent, rig2D.velocity.y);
            transform.DORotate(new Vector3(0, 180, 0), 0.1f);
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
            moveAnimBool = true;
            posY = transform.position.y;
            Invoke(nameof(AnimationJumpTo),0.01f);
        }
    }

    private void AnimationJumpTo()
    {
        if (transform.position.y > posY)
        {
            anim.SetBool(jumpAnim, true);
            posY = transform.position.y;
            Invoke(nameof(AnimationJumpTo), 0.01f);
        }
        else
        {
            anim.SetBool(jumpAnim, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && moveAnimBool)
        {
            anim.SetTrigger(jumpTriggerGroundAnim);
            moveAnimBool = false;
        }
    }

    public void damage(float dano)
    {
        healt -= dano;
        if (healt <= 0)
        {
            kill = true;
            moveAnimBool = false;
            anim.SetTrigger(animKill);
            Invoke(nameof(Kill),tempDelayKill);
        }
    }

    private void Kill()
    {
        gameManager.GameOver();
        healt = 0;
        Destroy(rig2D);
        Destroy(this);
    }
}