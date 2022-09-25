using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject gameObserver;
    public Enemy_SlimeMovement enemySlimeMovement;
    // public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;
       
        if (health <= 0 && enemySlimeMovement.isAlive == true)
        {
           
            enemySlimeMovement.KillMe();
        }
    }
}
