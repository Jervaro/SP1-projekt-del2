using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
	public int damage = 1;
	public int evolvedDamage = 3;

	public Vector3 attackOffset;
	public float attackRange = 2f;
	
	 
	
	public void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.gameObject.CompareTag("Player") == true)
		{
			collision.gameObject.GetComponent<PlayerState>().DoHarm(damage);
		}
		

	}



	

	
}
