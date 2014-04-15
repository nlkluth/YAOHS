using UnityEngine;
using System.Collections;
using System;

public class CharacterGeneration : MonoBehaviour 
{
	private PlayerCharacter _toon;
	private const int STARTING_POINTS = 350;
	private const int MIN_STARTING_ATTRIBUTE_VALUE = 10;
	private const int STARTING_VALUE = 50;
	private int pointsLeft;
	private const int OFFSET = 5;
	private const int LINE_HEIGHT = 20;
	private const int STAT_LABEL = 100;
	private const int BASEVALUE_LABEL_WIDTH = 30;
	private const int BUTTON_WIDTH = 20;
	private const int BUTTON_HEIGHT = 20;

	public GameObject playerPrefab;

	void Start()
	{
		var playerCharacter = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		playerCharacter.name = "pc";

		_toon = playerCharacter.GetComponent<PlayerCharacter>();
//		_toon.Awake();

		pointsLeft = STARTING_POINTS;
		for (int count = 0; count < Enum.GetValues(typeof(AttributeName)).Length; count++)
		{
			_toon.GetPrimaryAttribute(count).BaseValue = STARTING_VALUE;
			pointsLeft -= (STARTING_VALUE - MIN_STARTING_ATTRIBUTE_VALUE);
		}

		_toon.StatUpdate();
	}

	void OnGUI()
	{
		DisplayName();
		DisplayPointsLeft();
		DisplayAttributes();
		DisplayVitals();
		DisplaySkills();

		if (_toon.Name == "" || pointsLeft > 0) 
		{
				DisplayCreateLabel();
		} 
		else 
		{
				DisplayCreateButton();
		}
	}

	private void DisplayName()
	{
		GUI.Label(new Rect(10, 10, 50, 25), "Name: ");
		_toon.Name = GUI.TextField(new Rect(65, 10, 100, 25), _toon.Name);
	}

	private void DisplayAttributes()
	{
		for (int count = 0; count < Enum.GetValues(typeof(AttributeName)).Length; count++)
		{
			GUI.Label(new Rect(OFFSET, 40 + (count * LINE_HEIGHT), STAT_LABEL, LINE_HEIGHT), ((AttributeName)count).ToString());
			GUI.Label(new Rect(STAT_LABEL + OFFSET, 40 + (count * LINE_HEIGHT), BASEVALUE_LABEL_WIDTH, LINE_HEIGHT), _toon.GetPrimaryAttribute(count).AdjustedBaseValue.ToString());
			if (GUI.Button(new Rect(150, 40 + (count * BUTTON_HEIGHT), BUTTON_WIDTH, BUTTON_HEIGHT), "-") && 
			    _toon.GetPrimaryAttribute(count).BaseValue > MIN_STARTING_ATTRIBUTE_VALUE)
			{
				_toon.GetPrimaryAttribute(count).BaseValue--;
				pointsLeft++;
				_toon.StatUpdate();				
			}

			if (GUI.Button(new Rect(180, 40 + (count * BUTTON_HEIGHT), BUTTON_WIDTH, BUTTON_HEIGHT), "+") && pointsLeft > 0)
			{
				_toon.GetPrimaryAttribute(count).BaseValue++;
				pointsLeft--;
				_toon.StatUpdate();
			}
		}
	}

	private void DisplayVitals()
	{
		for (int count = 0; count < Enum.GetValues(typeof(VitalName)).Length; count++)
		{
			GUI.Label(new Rect(OFFSET, 40 + ((count + 7) * LINE_HEIGHT), STAT_LABEL, LINE_HEIGHT), ((VitalName)count).ToString());
			GUI.Label(new Rect(OFFSET + STAT_LABEL, 40 + ((count + 7) * LINE_HEIGHT), BASEVALUE_LABEL_WIDTH, LINE_HEIGHT), _toon.GetVital(count).AdjustedBaseValue.ToString());
		}
	}

	private void DisplaySkills()
	{
		for (int count = 0; count < Enum.GetValues(typeof(SkillName)).Length; count++)
		{
			GUI.Label(new Rect(250, 40 + (count * LINE_HEIGHT), STAT_LABEL, LINE_HEIGHT), ((SkillName)count).ToString());
			GUI.Label(new Rect(355, 40 + (count * LINE_HEIGHT), BASEVALUE_LABEL_WIDTH, LINE_HEIGHT), _toon.GetSkill(count).AdjustedBaseValue.ToString());
		}
	}

	private void DisplayPointsLeft()
	{
		GUI.Label(new Rect(250, 10, 100, 25), "Points Left: " + pointsLeft);
	}

	private void DisplayCreateLabel()
	{
		GUI.Label(new Rect (Screen.width / 2 - 50, 40 + (10 * LINE_HEIGHT), 100, LINE_HEIGHT), "Enter Name", "Button"); 
	}

	private void DisplayCreateButton()
	{
		if (GUI.Button(new Rect(Screen.width / 2 - 50, 40 + (10 * LINE_HEIGHT), 100, LINE_HEIGHT), "Create"))
		{
			GameSettings gameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
			UpdateCurrentValues();
			gameSettings.SaveCharacterData();
			Application.LoadLevel("Level1");
		}
	}

	private void UpdateCurrentValues()
	{
		for (int count = 0; count < Enum.GetValues(typeof(VitalName)).Length; count++) 
		{
			_toon.GetVital(count).Currentvalue = _toon.GetVital(count).AdjustedBaseValue;
		} 
	}
}
