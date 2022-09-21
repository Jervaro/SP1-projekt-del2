using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Killbox : MonoBehaviour
{
    GameObject gameObjectToKill;
    private int healthPoints;

    private void Start()
    {
        healthPoints = gameObject.GetComponentInParent<Enemy>().health;
        gameObjectToKill = gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true)
        {
            if(collision.gameObject.GetComponent<PlayerMovement>().isFalling() == true && healthPoints > 0)
            {
                gameObject.GetComponentInParent<Enemy_SlimeMovement>().KillMe();
                healthPoints = 0;
            }
        }
    }
}
