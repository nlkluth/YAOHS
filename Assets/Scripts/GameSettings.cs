using UnityEngine;
using System.Collections;
using System;

public class GameSettings : MonoBehaviour 
{
	public const string PLAYERSPAWN = "Player Spawn Point";

	void Awake()
	{
		DontDestroyOnLoad(this);
	}
	
	public void SaveCharacterData()
	{
		GameObject playerCharacter = GameObject.Find("pc");
		PlayerCharacter playerCharacterClass = playerCharacter.GetComponent<PlayerCharacter>();
		PlayerPrefs.DeleteAll();
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

			PlayerPrefs.SetString(((VitalName)count).ToString() + "Mods", playerCharacterClass.GetVital(count).GetModifyingAttributeString());
		}

		for (int count = 0; count < Enum.GetValues(typeof(SkillName)).Length; count++)
		{
			PlayerPrefs.SetInt(((SkillName)count).ToString(), playerCharacterClass.GetSkill(count).BaseValue);
			PlayerPrefs.SetInt(((SkillName)count).ToString() + " - Exp To Level", playerCharacterClass.GetSkill(count).ExpToLevel);

			PlayerPrefs.SetString(((SkillName)count).ToString() + "Mods", playerCharacterClass.GetSkill(count).GetModifyingAttributeString());
		}

	}

	public void LoadCharacterData()
	{
		GameObject playerCharacter = GameObject.Find("pc");
		PlayerCharacter playerCharacterClass = playerCharacter.GetComponent<PlayerCharacter>();

		playerCharacterClass.name = PlayerPrefs.GetString("Player Name", "Name me");

		for (int count = 0; count < Enum.GetValues(typeof(AttributeName)).Length; count++)
		{
			playerCharacterClass.GetPrimaryAttribute(count).BaseValue = PlayerPrefs.GetInt(((AttributeName)count).ToString(), 0);
			playerCharacterClass.GetPrimaryAttribute(count).ExpToLevel = PlayerPrefs.GetInt(((AttributeName)count).ToString() + " - Exp To Level", 0);
		}

		for (int count = 0; count < Enum.GetValues(typeof(VitalName)).Length; count++) 
		{
			playerCharacterClass.GetVital(count).BaseValue = PlayerPrefs.GetInt(((VitalName)count).ToString(), 0);
			playerCharacterClass.GetVital(count).ExpToLevel = PlayerPrefs.GetInt(((VitalName)count).ToString() + " - Exp To Level", 0);

			playerCharacterClass.GetVital(count).Update();
			playerCharacterClass.GetVital(count).Currentvalue = PlayerPrefs.GetInt(((VitalName)count).ToString() + " - Current Value", 10);
		}

		for (int count = 0; count < Enum.GetValues(typeof(VitalName)).Length; count++) 
		{

		}
	}
}
