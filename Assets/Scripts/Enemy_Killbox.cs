using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Killbox : MonoBehaviour
{
    GameObject gameObjectToKill;
    //private int healthPoints;
    private bool isAlive;

    private void Start()
    {
        //healthPoints = gameObject.GetComponentInParent<Enemy>().health;
        gameObjectToKill = gameObject.transform.parent.gameObject;
    }

    private void Update()
    {
        isAlive = gameObject.GetComponentInParent<Enemy_SlimeMovement>().isAlive;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true)
        {
            if(collision.gameObject.GetComponent<PlayerMovement>().isFalling() == true && isAlive == true)
            {
                gameObject.GetComponentInParent<Enemy_SlimeMovement>().KillMe();
                //healthPoints = 0;
            }
        }
    }
}
