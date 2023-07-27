using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, delay, dano;

    private void Start()
    {
        Invoke(nameof(Kill), delay);
    }

    private void Update()
    {
        transform.Translate(new Vector2(speed, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().damage(dano);
            Kill();
        }
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}