﻿using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour 
{
	public GameObject playerCharacter;
	public Camera mainCamera;
	public float zOffset;
	public float yOffset;
	public float xRotOffset;

	private GameObject _player;
	private PlayerCharacter _playerCharacterScript;

	void Start() 
	{
		_player = Instantiate (playerCharacter, Vector3.zero, Quaternion.identity) as GameObject;
		_playerCharacterScript = _player.GetComponent<PlayerCharacter>();

		zOffset = -2.5f;
		yOffset = 2.5f;
		xRotOffset = 22.5f;

		mainCamera.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + yOffset,
		                                            _player.transform.position.z + zOffset);
		mainCamera.transform.Rotate(xRotOffset, 0, 0);
	}
	
	public void LoadCharacter()
	{
		GameSettings gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();

	gameSettings.LoadCharacterData();
	}
}
