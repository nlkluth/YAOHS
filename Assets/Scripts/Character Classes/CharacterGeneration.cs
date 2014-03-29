using UnityEngine;
using System.Collections;
using System;

public class CharacterGeneration : MonoBehaviour 
{
	private PlayerCharacter _toon;

	void Start()
	{
		_toon = new PlayerCharacter();
		_toon.Awake();
	}

	void OnGUI()
	{
		DisplayName();
		DisplayAttributes();
		DisplayAttributes();
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
		}
	}

	private void DisplayVitals()
	{

	}

	private void DisplaySkills()
	{
		
	}
}
