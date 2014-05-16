using UnityEngine;
using System.Collections;

public class Mob : BaseCharacter 
{
	public int currentHealth;
	public int maxHealth;

	void Start ()
	{
//		GetPrimaryAttribute((int)AttributeName.Constitution).BaseValue = 100;
//		GetVital((int)VitalName.Health).Update();

		Name = "Spidey";
	}

	void Update () 
	{
	}

	public void DisplayHealth()
	{
		Messenger<int, int>.Broadcast("mob health update", currentHealth, maxHealth);
	}
}
