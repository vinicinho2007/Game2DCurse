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
    public GameObject PFBParticleSystemJump;
    public SOSetupPlayer setupPlayer;
    public Rigidbody2D rig2D;
    public bool turned;
    private float _speedCurrent;

    [Header("Animation")]
    public Animator anim;
    private string _moveAnim;
    private bool moveAnimBool;
    private float posY;

    [Header("Vida")]
    public GameObject PFBParticleSystemDano;
    public bool invincible;
    public float healt;
    public DamageColor damageColor;

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
            _speedCurrent = setupPlayer.speedRun;
            _moveAnim = setupPlayer.nameSpeedRun;
        }
        else
        {
            _speedCurrent = setupPlayer.speed;
            _moveAnim = setupPlayer.nameRun;
        }

        if (Input.GetAxisRaw("Horizontal") != 0 && !moveAnimBool)
        {
            anim.SetBool(_moveAnim, true);
        }
        else
        {
            anim.SetBool(_moveAnim, false);
        }

        if (Input.GetAxisRaw("Horizontal")>0)
        {
            turned = false;
            rig2D.velocity = new Vector2(_speedCurrent, rig2D.velocity.y);
            transform.DORotate(new Vector3(0, 0, 0), 0.1f);
        }
        if (Input.GetAxisRaw("Horizontal")<0)
        {
            turned = true;
            rig2D.velocity = new Vector2(-_speedCurrent, rig2D.velocity.y);
            transform.DORotate(new Vector3(0, 180, 0), 0.1f);
        }

        if (rig2D.velocity.x > 0)
        {
            rig2D.velocity += setupPlayer.friction;
        }
        else if (rig2D.velocity.x < 0)
        {
            rig2D.velocity -= setupPlayer.friction;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig2D.velocity = transform.up * setupPlayer.forceJump;
            moveAnimBool = true;
            posY = transform.position.y;
            Invoke(nameof(AnimationJumpTo),0.01f);
            Instantiate(PFBParticleSystemJump, transform).transform.SetParent(null);
        }
    }

    private void AnimationJumpTo()
    {
        if (transform.position.y > posY)
        {
            anim.SetBool(setupPlayer.jumpAnim, true);
            posY = transform.position.y;
            Invoke(nameof(AnimationJumpTo), 0.01f);
        }
        else
        {
            anim.SetBool(setupPlayer.jumpAnim, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && moveAnimBool)
        {
            anim.SetTrigger(setupPlayer.jumpTriggerGroundAnim);
            moveAnimBool = false;
        }
    }

    public void damage(float dano)
    {
        Instantiate(PFBParticleSystemDano,transform);
        if (!invincible)
        {
            healt -= dano;
        }
        damageColor.ColorDamage();
        if (healt <= 0)
        {
            kill = true;
            moveAnimBool = false;
            anim.SetTrigger(setupPlayer.animKill);
            Invoke(nameof(Kill), setupPlayer.tempDelayKill);
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