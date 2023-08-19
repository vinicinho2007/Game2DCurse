using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public SOFloat dano;
    public Player player;
    public GameObject projectile;
    public Transform target;
    public float delay;
    private bool shot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shot();
        }
    }

    private void Shot()
    {
        if (!shot)
        {
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