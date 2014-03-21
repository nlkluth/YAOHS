
public class BaseStat
{
	private int _baseValue;
	private int _buffValue;
	private int _expToLevel;
	private float _levelModifier;

	public BaseStat()
	{
		_baseValue = 0;
		_buffValue = 0;
		_levelModifier = 1.1f;
		_expToLevel = 100;
	}

	private int BaseValue { get; set; }
	private int BuffValue { get; set; }
	private int ExpToLevel { get; set; }
	private float LevelModifier { get; set; }

	private int CalculateExpTolevel()
	{
		return _expToLevel * _levelModifier;
	}

	public void LevelUp()
	{
		_expToLevel = CalculateExpTolevel();
		_baseValue++;
	}

	public int AdjustedValue()
	{
		return _baseValue + _buffValue;
	}
}
