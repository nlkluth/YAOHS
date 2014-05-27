using UnityEngine;
using System.Collections;

public class Armor : Clothing 
{
	public int ArmorLevel { get; set; }

	public Armor()
	{
		ArmorLevel = 0;
	}

	public Armor(int armorLevel)
	{
		ArmorLevel = armorLevel;
	}
}
