using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
	public GameObject target;
	public float attackTimer;
	public float cooldown;
	
	void Start() 
	{
		attackTimer = 0f;
		cooldown = 2.0f;
	}
	
	void Update() 
	{
		if (attackTimer > 0)
		{
			attackTimer -= Time.deltaTime;
		}
		
		if (attackTimer < 0)
		{
			attackTimer = 0;
		}

		if (attackTimer == 0)
		{
			Attack();
			attackTimer = cooldown;
		}
	}
	
	private void Attack()
	{
		float distance = Vector3.Distance(target.transform.position, transform.position);
		
		Vector3 forward = (target.transform.position - transform.position).normalized;
		float direction = Vector3.Dot(forward, transform.forward);
		
		if (distance < 2.5f)
		{
			if (direction > 0)
			{
				PlayerHealth playerHealth = (PlayerHealth)target.GetComponent("PlayerHealth");
				playerHealth.AdjustCurrentHealth(-10);
			}
		}
	}
}
