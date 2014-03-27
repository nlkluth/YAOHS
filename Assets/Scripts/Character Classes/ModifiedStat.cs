using System.Collections.Generic;

public class ModifiedStat : BaseStat 
{
	private List<ModifyingAttribute> _modifiers;
	private int _modifiedValue;

	public ModifiedStat()
	{
		_modifiers = new List<ModifyingAttribute>();
		_modifiedValue = 0;
	}

	public void AddModifier(ModifyingAttribute modifier)
	{
		_modifiers.Add(modifier);
	}

	private void CalculateModifiedValue()
	{
		_modifiedValue = 0;

		if (_modifiers.Count > 0)
		{
			foreach (ModifyingAttribute attribute in _modifiers)
			{
				_modifiedValue += (int)(attribute.attribute.AdjustedBaseValue * attribute.ratio);
			}
		}
	}

	public new int AdjustedBaseValue
	{
		get { return BaseValue + BuffValue + _modifiedValue; }
	}

	public void Update()
	{
		CalculateModifiedValue();
	}
}

public struct ModifyingAttribute
{
	public Attribute attribute;
	public float ratio;

	public ModifyingAttribute(Attribute _attribute, float _ratio)
	{
		attribute = _attribute;
		ratio = _ratio;
	}
}
