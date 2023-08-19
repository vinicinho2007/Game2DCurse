using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public TextMeshProUGUI textMunitions;
    public SOFloat dano, maxMunition;
    public Player player;
    public GameObject projectile;
    public Transform target;
    public float delay;
    public float _maxMunition;
    private bool shot;

    private void Start()
    {
        textMunitions = GameObject.Find("Text_Munition").GetComponent<TextMeshProUGUI>();
        _maxMunition = maxMunition.value;
    }

    private void Update()
    {
        textMunitions.text = "x" + _maxMunition;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shot();
        }
    }

    private void Shot()
    {
        if (!shot && _maxMunition > 0)
        {
            _maxMunition--;
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