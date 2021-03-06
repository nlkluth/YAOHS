﻿using UnityEngine;
using System.Collections;

public class Item
{
	public string Name { get; set; }
	public int Value { get; set; }
	public Rarity Rarity { get; set; }
	public int CurrentDurability { get; set; }
	public int MaxDurability { get; set; }

	public Item()
	{
		Name = "Need Name";
		Value = 0;
		Rarity = Rarity.Common;
		MaxDurability = 50;
		CurrentDurability = MaxDurability;
	}

	public Item(string name, int value, Rarity rarity, int maxDurability)
	{
		Name = name;
		Value = value;
		Rarity = rarity;
		MaxDurability = maxDurability;
	}
}

public enum Rarity 
{
	Common,
	Uncommon,
	Rare
}
