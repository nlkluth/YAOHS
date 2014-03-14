using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour 
{
	public GameObject target;

	void Start() 
	{
		
	}
	
	void Update() 
	{
		if (Input.GetKeyUp(KeyCode.F))
		{
			Attack();
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
				EnemyHealth enemyHealth = (EnemyHealth)target.GetComponent("EnemyHealth");
				enemyHealth.AdjustCurrentHealth(-10);
			}
		}
	}
}
