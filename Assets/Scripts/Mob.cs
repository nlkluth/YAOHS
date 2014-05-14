using UnityEngine;
using System.Collections;

public class Mob : BaseCharacter 
{
	void Start ()
	{
		GetPrimaryAttribute(int)AttributeName.Constitution)).BaseValue = 100;
	}

	void Update () 
	{
		Messenger<int, int>.Broadcast("mob health update", 100, 80);
	}
}
