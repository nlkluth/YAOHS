using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
		if (!CheckForMobPrefabs() || !CheckForSpawnPoints()) 
		{
			return;
		}
		state = State.Setup;
	}

	private void Setup()
	{
		Debug.Log ("setup");
		state = State.SpawnMob;
	}

	private void SpawnMob()
	{
		GameObject[] availableSpawnPoints = AvailableSpawnPoints();
		for (int i = 0; i < availableSpawnPoints.Length; i++)
		{
			GameObject randomMob = Instantiate(mobPrefabs[Random.Range(0, mobPrefabs.Length)],
	                                   availableSpawnPoints[i].transform.position, Quaternion.identity) as GameObject;

			randomMob.transform.parent = availableSpawnPoints[i].transform;
		}

		state = State.Idle;
	}

	private bool CheckForMobPrefabs()
	{
		if (mobPrefabs.Length > 0) 
		{
			return true;
		}

		return false;
	}

	private bool CheckForSpawnPoints()
	{
		if (spawnPoints.Length > 0) 
		{
			return true;
		}

		return false;
	}

	private GameObject[] AvailableSpawnPoints()
	{
		List<GameObject> gameObjects = new List<GameObject>();

		for (int i = 0; i < spawnPoints.Length; i++)
		{
			if (spawnPoints[i].transform.childCount == 0)
			{
				gameObjects.Add(spawnPoints[i]);
			}
		}

		return gameObjects.ToArray();
	}
}
