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
		SpawnMob	
	}

	public State state;

	void Awake()
	{
		state = State.Initialze;
	}

	IEnumerator Start () 
	{
		while(true) 
		{
			switch(state)
			{
				case State.Initialze:
					Initialize();
					break;
				case State.Setup:
					Setup();
					break;
				case State.SpawnMob:
					SpawnMob();
					break;
			}

			yield return 0;
		}
	}
	
	private void Initialize()
	{
		Debug.Log ("init");
	}

	private void Setup()
	{
		Debug.Log ("setup");
	}

	private void SpawnMob()
	{
		Debug.Log ("spawnmob");
	}
}
