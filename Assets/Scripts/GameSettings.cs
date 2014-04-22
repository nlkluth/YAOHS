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

		for (int count = 0; count < Enum.GetValues(typeof(AttributeName)).Length; count++) 
		{
			playerCharacterClass.GetVital(count).BaseValue = PlayerPrefs.GetInt(((VitalName)count).ToString(), 0);
			playerCharacterClass.GetVital(count).ExpToLevel = PlayerPrefs.GetInt(((VitalName)count).ToString() + " - Exp To Level", 0);

			string playerMods = PlayerPrefs.GetString(((VitalName)count).ToString() + "Mods","");
			string[] mods = playerMods.Split('|');

			foreach(string s in mods)
			{
				string[] modStats = s.Split('_');

				int attributeIndex = 0;
				for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++) 
				{
					if (modStats[0] == ((AttributeName)i).ToString())
					{
						attributeIndex = i;
						break;
					}
					playerCharacterClass.GetVital((int)VitalName.Health).AddModifier(new ModifyingAttribute(GetPrimaryAttribute(attributeIndex), modStats[i]));
   			    }
			}

//			PlayerPrefs.SetString(((VitalName)count).ToString() + "Mods", playerCharacterClass.GetVital(count).GetModifyingAttributeString());
//			playerCharacterClass.GetVital(count).Currentvalue = PlayerPrefs.GetInt(((VitalName)count).ToString() + " - Current Value", 0);			
		}
	}
}
