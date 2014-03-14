using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
	public float maxHealth = 100;
	public float currentHealth = 100;
	public float healthBarLength;

	void Start()
	{
		healthBarLength = Screen.width / 2;
	}

	void Update()
	{
		AdjustCurrentHealth(0);
	}

	public void AdjustCurrentHealth(int adjustment)
	{
		currentHealth += adjustment;

		if (currentHealth < 0) 
		{
			currentHealth = 0;
		}

		if (currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}

		if (maxHealth < 1)
		{
			maxHealth = 1;
		}

		healthBarLength = (Screen.width/2) * (currentHealth / maxHealth);
	}

	private void OnGUI()
	{
		GUI.Box(new Rect(10, 40, healthBarLength, 20), currentHealth + " / " + maxHealth);
	}
}
