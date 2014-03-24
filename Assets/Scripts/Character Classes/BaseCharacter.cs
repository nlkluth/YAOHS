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

	public Attribute GetPrimaryAttribute(int index)
	{
		return _primaryAttribute[index];
	}

	public Skill GetSkill(int index)
	{
		return _skill[index];
	}

	public Vital GetVital(int index)
	{
		return _vital[index];
	}

	private void SetupVitalModifiers()
	{
		ModifyingAttribute health = new ModifyingAttribute();
		health.attribute = GetPrimaryAttribute((int)AttributeName.Constitution);
		health.ratio = 0.5f;

		GetVital((int)VitalName.Health).AddModifier(health);

		ModifyingAttribute energy = new ModifyingAttribute();
		energy.attribute = GetPrimaryAttribute((int)AttributeName.Constitution);
		energy.ratio = 1f;
		
		GetVital((int)VitalName.Energy).AddModifier(energy);

		ModifyingAttribute mana = new ModifyingAttribute();
		health.attribute = GetPrimaryAttribute((int)AttributeName.Willpower);
		health.ratio = 1f;
		
		GetVital((int)VitalName.Mana).AddModifier(mana);
	}

	private void SetupSkillModifiers()
	{
		ModifyingAttribute MeleeOffenseModifier1 = new ModifyingAttribute();
		ModifyingAttribute MeleeOffenseModifier2 = new ModifyingAttribute();

		MeleeOffenseModifier1.attribute = GetPrimaryAttribute((int)AttributeName.Might);
		MeleeOffenseModifier1.ratio = 0.33f;

		MeleeOffenseModifier2.attribute = GetPrimaryAttribute((int)AttributeName.Nimbleness);
		MeleeOffenseModifier2.ratio = 0.33f;

		GetSkill((int)SkillName.Melee_Offense).AddModifier(MeleeOffenseModifier1);
		GetSkill((int)SkillName.Melee_Offense).AddModifier(MeleeOffenseModifier1);
	}
}
