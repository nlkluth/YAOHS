using UnityEngine;
using System.Collections;

public class Item
{
	public string Name { get; set; }
	public int Value { get; set; }
	public Rarity Rarity { get; set; }
}

public enum Rarity 
{
	Common,
	Uncommon,
	Rare
}
