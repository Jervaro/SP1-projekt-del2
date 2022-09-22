using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject gameObserver;

    // public GameObject deathEffect;

    public Enemy_SlimeMovement enemySlimeMovement;

    public void TakeDamage(int damage)
    {
        health -= damage;
       
        if (health <= 0)
        {
           
            enemySlimeMovement.KillMe();
        }
    }
}
