using UnityEngine;
using System.Collections;

public class BuffItem : Item 
{
	private Hashtable buffs;
	private Hashtable modifiers;

	public BuffItem()
	{
		buffs = new Hashtable ();
	}

	public BuffItem(Hashtable hashtable)
	{
		buffs = hashtable;
	}

	public void AddBuff(BaseStat stat, int modifier)
	{
		try
		{
			buffs.Add(stat.Name, modifier);
		}
		catch(Exception e)
		{
			Debug.LogWarning(e);
		}
	}

	public void RemoveBuff(BaseStat stat)
	{
		buffs.Remove(stat.Name);
	}

	public int BuffCount()
	{
		return buffs.Count();
	}

	public Hashtable BuffList()
	{
		return buffs;
	}
}
