using UnityEngine;

public class Jewelry : BuffItem
{
	public JewelrySlot Slot { get; set; }

	public Jewelry() 
	{
		Slot = JewelrySlot.Necklace;
	}

	public Jewelry(JewelrySlot slot)
	{
		Slot = slot;
	}
}

public enum JewelrySlot
{
	Earrings,
	Necklace,
	Bracelets,
	Rings,
	Trinkets
}
