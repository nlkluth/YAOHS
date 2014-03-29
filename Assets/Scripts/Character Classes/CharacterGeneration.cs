using UnityEngine;
using System.Collections;

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
		GUI.Label(new Rect(10, 10, 50, 25), "Name: ");
		_toon.Name = GUI.TextArea(new Rect(65, 10, 100, 25), _toon.Name);

		for (int count = 0; count < Enum.GetValues(typeof(AttributeName)).Length; count++)
		{

		}
	}
}
