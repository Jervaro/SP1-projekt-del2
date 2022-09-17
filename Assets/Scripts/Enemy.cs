using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int health = 100;
    public bool isHurt = false;

    // public GameObject deathEffect;

    public Enemy_SlimeMovement enemySlimeMovement;

    public void TakeDamage(int damage)
    {
        health -= damage;
        isHurt = true;
        if (health <= 0)
        {
            enemySlimeMovement.KillMe();
        }
    }

    private void Update()
    {

    }
    
}
