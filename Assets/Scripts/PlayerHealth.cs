using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
	public int maxHealth = 100;
	public int currentHealth = 100;

	private void OnGUI()
	{
		GUI.Box(new Rect(10, 10, (Screen.width/2)/(maxHealth/currentHealth), 20), currentHealth + " / " + maxHealth);
	}
}
