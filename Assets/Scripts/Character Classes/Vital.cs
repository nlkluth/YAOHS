public class Vital : ModifiedStat 
{
	private int _currentValue;

	public Vital()
	{
		_currentValue = 0;
		ExpToLevel = 50;
		LevelModifier = 1.1f;
	}

	private int Currentvalue
	{ 
		get
		{
			if (_currentValue > AdjustedBaseValue)
			{
				_currentValue = AdjustedBaseValue;
			}
			return _currentValue;
		}
		set { _currentValue = value; } 
	}
}

public enum VitalName
{
	Health,
	Energy,
	Mana
}
