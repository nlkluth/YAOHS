using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
	public int maxHealth = 100;
	public int currentHealth = 100;
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
		healthBarLength = (Screen.width/2) * (currentHealth / (float)maxHealth);
	}

	private void OnGUI()
	{
		GUI.Box(new Rect(10, 10, healthBarLength, 20), currentHealth + " / " + maxHealth);
	}
}
