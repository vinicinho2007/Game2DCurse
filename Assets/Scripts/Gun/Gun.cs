using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [Header("Outros Scripts")]
    private GameManager gameManager;

    public SOFloat dano;
    public Player player;
    public GameObject projectile;
    public Transform target;
    public float delay;
    public SOInt maxMunition, munitionContinue;
    private bool shot;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        munitionContinue.value = maxMunition.value;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&& !gameManager.openMenu)
        {
            Shot();
        }
    }

    private void Shot()
    {
        if (!shot && munitionContinue.value > 0)
        {
            munitionContinue.value--;
            GameObject obj = Instantiate(projectile, target.position, projectile.transform.rotation);
            if (player.turned)
            {
                Vector3 rot = projectile.transform.eulerAngles;
                obj.transform.localEulerAngles = new Vector3(rot.x, 180, rot.z);
            }
            obj.GetComponent<Projectile>().dano = dano;
            shot = true;
            Invoke(nameof(DelayShot), delay);
        }
    }

    private void DelayShot()
    {
        shot = false;
    }
}