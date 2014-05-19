﻿using UnityEngine;
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
		if (!CheckForMobPrefabs() || CheckForSpawnPoints()) 
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
		Debug.Log ("spawnmob");
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
}
