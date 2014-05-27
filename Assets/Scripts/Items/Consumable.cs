using UnityEngine;
using System.Collections;

public class Consumable : BuffItem
{
	public Vital[] Vital;
	public int[] AmountToHeal;
	public float BuffTime;

	public Consumable() 
	{
		Reset();
	}

	public Consumable(Vital[] vital, int[] amountToHeal, float buffTime)
	{
		Vital = vital;
		AmountToHeal = amountToHeal;
		BuffTime = buffTime;
	}

	public void Reset()
	{
		BuffTime = 0;

		for (int count = 0; count < Vital.Length; count++)
		{
			Vital[count] = new Vital();
			AmountToHeal[count] = 0;
		}
	}

	public int VitalCount()
	{
		return Vital.Length;
	}
}
