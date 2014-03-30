using UnityEngine;
using System.Collections;
using System;

public class BaseCharacter : MonoBehaviour 
{
	private Attribute[] _primaryAttribute;
	private Vital[] _vital;
	private Skill[] _skill;

	public void Awake()
	{
		Name = string.Empty;
		Level = 0;
		FreeExp = 0;

		_primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
		_skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];
		_vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];

		SetupPrimaryAttributes();
		SetupVitals();
		SetupSkills();
	}

	public string Name { get; set; }
	public int Level { get; set; }
	public uint FreeExp { get; set; }

	public void AddExperience(uint experience)
	{
		FreeExp += experience;

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

		SetupVitalModifiers();
	}

	private void SetupSkills()
	{
		for (int count = 0; count < _skill.Length; count++)
		{
			_skill[count] = new Skill();
		}

		SetupSkillModifiers();
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
		GetVital((int)VitalName.Health).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), .5f));
		GetVital((int)VitalName.Energy).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), 1f));
		GetVital((int)VitalName.Mana).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), 1f));
	}

	private void SetupSkillModifiers()
	{
		GetSkill((int)SkillName.Melee_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Might), .33f));
		GetSkill((int)SkillName.Melee_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Nimbleness), .33f));

		GetSkill((int)SkillName.Melee_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
		GetSkill((int)SkillName.Melee_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), .33f));

		GetSkill((int)SkillName.Magic_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
		GetSkill((int)SkillName.Magic_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), .33f));

		GetSkill((int)SkillName.Magic_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
		GetSkill((int)SkillName.Magic_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), .33f));

		GetSkill((int)SkillName.Ranged_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
		GetSkill((int)SkillName.Ranged_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));

		GetSkill((int)SkillName.Ranged_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
		GetSkill((int)SkillName.Ranged_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Nimbleness), .33f));
	}

	public void StatUpdate()
	{
		for (int count = 0; count < _vital.Length; count++)
		{
			_vital[count].Update();
		}

		for (int count = 0; count < _skill.Length; count++)
		{
			_skill[count].Update();
		}
	}
}
