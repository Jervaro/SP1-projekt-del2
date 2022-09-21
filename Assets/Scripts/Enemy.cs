using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject gameObserver;
    private PlayerState playerState;

    // public GameObject deathEffect;

    public Enemy_SlimeMovement enemySlimeMovement;

    private void Start()
    {
        playerState = GameObject.Find("Player").GetComponent<PlayerState>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            enemySlimeMovement.KillMe();
            playerState.killedAmount++;
        }
    }
}
