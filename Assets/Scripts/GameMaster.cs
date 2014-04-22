using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour 
{
	public GameObject playerCharacter;
	public GameObject gameSettings;	
	public Camera mainCamera;
	public float zOffset;
	public float yOffset;
	public float xRotOffset;

	private GameObject _player;
	private PlayerCharacter _playerCharacterScript;
	private Vector3 _playerSpawnPosition;

	void Start() 
	{
		_playerSpawnPosition = new Vector3(70, 1.5, 45);
		GameObject spawnPoint = GameObject.Find(GameSettings.PLAYERSPAWN);

		if (spawnPoint == null) 
		{
			spawnPoint = new GameObject(GameSettings.PLAYERSPAWN);
			spawnPoint.transform.position = _playerSpawnPosition;
		}

		_player = Instantiate (playerCharacter, spawnPoint.transform.position, Quaternion.identity) as GameObject;
		_player.name = "";
		_playerCharacterScript = _player.GetComponent<PlayerCharacter>();

		zOffset = -2.5f;
		yOffset = 2.5f;
		xRotOffset = 22.5f;

		mainCamera.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + yOffset,
		                                            _player.transform.position.z + zOffset);
		mainCamera.transform.Rotate(xRotOffset, 0, 0);

		LoadCharacter();
	}
	
	public void LoadCharacter()
	{
		GameObject gameSettings = GameObject.Find("");

		if (gameSettings == null) 
		{
			GameObject newGameSettings = Instantiate(gameSettings, Vector3.zero, Quaternion.identity) as GameObject;
			newGameSettings.name = "gameSettings";
		}

		GameSettings gameSettingsScript = GameObject.Find("GameSettings").GetComponent<GameSettings>();

		gameSettingsScript.LoadCharacterData();
	}
}
