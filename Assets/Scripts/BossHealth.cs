using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
	public int health = 1000;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 500)
		{
			GetComponent<Animator>().SetBool("IsEvolved", true);
			gameObject.GetComponent<BossAttack>().damage = gameObject.GetComponent<BossAttack>().evolvedDamage;
		}

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);

	}
}
