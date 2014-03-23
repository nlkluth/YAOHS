using UnityEngine;
using System.Collections;
using System;

public class BaseCharacter : MonoBehaviour 
{
	private string _name;
	private int _level;
	private uint _freeExperience;
	private Attribute[] _primaryAttribute;
	private Vital[] _vital;
	private Skill[] _skill;

	void Awake()
	{
		_name = string.Empty;
		_level = 0;
		_freeExperience = 0;

		_primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
		_skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];
		_vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
	}

	public void AddExperience(uint experience)
	{
		_freeExperience += experience;

		CalculateLevel();
	}

	public void CalculateLevel()
	{

	}

	private void SetupPrimaryAttributes()
	{
		for (int count = 0; count < _primaryAttribute.Length; count++)
		{
			_primaryAttribute[count] = new Attribute();
		}
	}

	private void SetupVitals()
	{
		for (int count = 0; count < _vital.Length; count++)
		{
			_vital[count] = new Vital();
		}
	}

	private void SetupSkills()
	{
		for (int count = 0; count < _skill.Length; count++)
		{
			_skill[count] = new Skill();
		}
	}
}
