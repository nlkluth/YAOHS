using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour 
{
	public GameObject PlayerPrefab;	

	void Awake()
	{
		DontDestroyOnLoad(this);
	}
	
	public void SaveCharacterData()
	{
		GameObject playerCharacter = GameObject.Find("playerCharacter");
		PlayerCharacter playerCharacterClass = playerCharacter.GetComponent<PlayerCharacter>();
		PlayerPrefs.SetString("Player Name", "test");
	}

	public void LoadCharacterData()
	{}
}
