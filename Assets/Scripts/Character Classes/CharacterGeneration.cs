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

	void Start()
	{
		_toon = new PlayerCharacter();
		_toon.Awake();

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
	}

	private void DisplayName()
	{
		GUI.Label(new Rect(10, 10, 50, 25), "Name: ");
		_toon.Name = GUI.TextArea(new Rect(65, 10, 100, 25), _toon.Name);
	}

	private void DisplayAttributes()
	{
		for (int count = 0; count < Enum.GetValues(typeof(AttributeName)).Length; count++)
		{
			GUI.Label(new Rect(10, 40 + (count * 25), 100, 25), ((AttributeName)count).ToString());
			GUI.Label(new Rect(115, 40 + (count * 25), 30, 25), _toon.GetPrimaryAttribute(count).AdjustedBaseValue.ToString());
			if (GUI.Button(new Rect(150, 40 + (count * 25), 25, 25), "-") && 
			    _toon.GetPrimaryAttribute(count).BaseValue > MIN_STARTING_ATTRIBUTE_VALUE)
			{
				_toon.GetPrimaryAttribute(count).BaseValue--;
				pointsLeft++;
				_toon.StatUpdate();				
			}

			if (GUI.Button(new Rect(180, 40 + (count * 25), 25, 25), "+") && pointsLeft > 0)
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
			GUI.Label(new Rect(10, 40 + ((count + 7) * 25), 100, 25), ((VitalName)count).ToString());
			GUI.Label(new Rect(115, 40 + ((count + 7) * 25), 30, 25), _toon.GetVital(count).AdjustedBaseValue.ToString());
		}
	}

	private void DisplaySkills()
	{
		for (int count = 0; count < Enum.GetValues(typeof(SkillName)).Length; count++)
		{
			GUI.Label(new Rect(250, 40 + (count * 25), 100, 25), ((SkillName)count).ToString());
			GUI.Label(new Rect(355, 40 + (count * 25), 30, 25), _toon.GetSkill(count).AdjustedBaseValue.ToString());
		}
	}

	private void DisplayPointsLeft()
	{
		GUI.Label(new Rect(250, 10, 100, 25), "Points Left: " + pointsLeft);
	}
}
