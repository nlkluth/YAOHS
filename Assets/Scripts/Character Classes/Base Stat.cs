
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

	public int BaseValue { get; set; }
	public int BuffValue { get; set; }
	public int ExpToLevel { get; set; }
	public float LevelModifier { get; set; }

	private int CalculateExpTolevel()
	{
		return (int)(_expToLevel * _levelModifier);
	}

	public void LevelUp()
	{
		_expToLevel = CalculateExpTolevel();
		_baseValue++;
	}

	public int AdjustedBaseValue
	{
		get { return _baseValue + _buffValue; }
	}
}
