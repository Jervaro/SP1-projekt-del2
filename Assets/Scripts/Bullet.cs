using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 50;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") == true)
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    
        if(collision.CompareTag("Boss") == true)
        {
            BossHealth boss = collision.GetComponent<BossHealth>();
            boss.TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
