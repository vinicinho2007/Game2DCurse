using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Outros Scripts")]
    private GameManager gameManager;

    [Header("Animação")]
    public Animator anim;
    public string attackAnim, dealthAnim;

    [Header("Velocidade e Ataque")]
    public float delayAttack;
    private Player player;
    private bool attackBool;

    [Header("Vida e Dano")]
    public SOInt enemys;
    public SourcesEnemy sourcesEnemy;
    public GameObject PFBparticleSystem;
    public float dano;
    public float healt, delayKill;
    public DamageColor damageColor;

    [Header("Depois da Morte")]
    public Transform target;
    public GameObject coin;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player = collision.gameObject.GetComponent<Player>();
        if (player!=null)
        {
            if (!attackBool&&player.healt>0&&healt>0&&!gameManager.openMenu)
            {
                anim.SetTrigger(attackAnim);
                player.damage(dano);
                Invoke(nameof(BoolAttack), delayAttack);
                attackBool = true;
            }
        }
    }

    private void BoolAttack()
    {
        attackBool = false;
    }

    public void damage(float dano)
    {
        Instantiate(PFBparticleSystem, transform);
        damageColor.ColorDamage();
        sourcesEnemy.Dano();
        healt -= dano;
        if (healt <= 0)
        {
            anim.SetTrigger(dealthAnim);
            healt = 0;
            Destroy(GetComponent<Rigidbody2D>());
            Invoke(nameof(Kill), delayKill);
        }
    }

    private void Kill()
    {
        enemys.value++;
        Instantiate(coin, target.position, coin.transform.rotation);
        Destroy(gameObject);
    }
}