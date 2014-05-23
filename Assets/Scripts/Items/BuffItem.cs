using UnityEngine;
using System.Collections;

public class BuffItem : Item 
{
	private Hashtable buffs;
	private Hashtable modifiers;

	public BuffItem()
	{

	}

	public void AddBuff(BaseStat stat, int modifier)
	{
		buffs.Add(stat.Name, modifier);
	}
}
