using UnityEngine;
using System.Collections;

public class MobGeneration : MonoBehaviour 
{
	public GameObject[] mobPrefabs;
	public GameObject[] spawnPoints;
	public enum State 
	{
		Idle,
		Initialze,
		Setup,
		Actions	
	}

	public State state;

	void Start () 
	{
		while(true) 
		{
			switch(state)
			{
				case State.Initialze:
					break;
				case State.Setup:
					break;
				case State.Actions:
					break;
			}
		}
	}
	
	private void Initialize()
	{
		Debug.Log ("init");
	}
}
