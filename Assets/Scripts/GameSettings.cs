using UnityEngine;
using System.Collections;
using System;

public class GameSettings : MonoBehaviour 
{
	void Awake()
	{
		DontDestroyOnLoad(this);
	}
	
	public void SaveCharacterData()
	{
		GameObject playerCharacter = GameObject.Find("pc");
		PlayerCharacter playerCharacterClass = playerCharacter.GetComponent<PlayerCharacter>();
		PlayerPrefs.SetString("Player Name", playerCharacterClass.Name);

		for (int count = 0; count < Enum.GetValues(typeof(AttributeName)).Length; count++)
		{
			PlayerPrefs.SetInt(((AttributeName)count).ToString(), playerCharacterClass.GetPrimaryAttribute(count).BaseValue);
			PlayerPrefs.SetInt(((AttributeName)count).ToString() + " - Exp To Level", playerCharacterClass.GetPrimaryAttribute(count).ExpToLevel);
		}

		for (int count = 0; count < Enum.GetValues(typeof(VitalName)).Length; count++)
		{
			PlayerPrefs.SetInt(((VitalName)count).ToString(), playerCharacterClass.GetVital(count).BaseValue);
			PlayerPrefs.SetInt(((VitalName)count).ToString() + " - Exp To Level", playerCharacterClass.GetVital(count).ExpToLevel);
			PlayerPrefs.SetInt(((VitalName)count).ToString() + " - Current Value", playerCharacterClass.GetVital(count).Currentvalue);
		}

	}

	public void LoadCharacterData()
	{}
}
