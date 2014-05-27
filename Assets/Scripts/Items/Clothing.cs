using UnityEngine;
using System.Collections;

public class Clothing : BuffItem 
{
	public ArmorSlot Slot { get; set; }

	public Clothing()
	{
		Slot = ArmorSlot.Head;
	}

	public Clothing(ArmorSlot slot)
	{
		Slot = slot;
	}
}

public enum ArmorSlot
{
	Head,
	Shoulder,
	Chest,
	Back,
	Belt,
	Legs,
	Feet,
	Hands
}
