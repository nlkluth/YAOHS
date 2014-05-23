
public class BaseStat
{
	public BaseStat()
	{
		BaseValue = 0;
		BuffValue = 0;
		LevelModifier = 1.1f;
		ExpToLevel = 100;
		Name = "";
	}

	public int BaseValue { get; set; }
	public int BuffValue { get; set; }
	public int ExpToLevel { get; set; }
	public float LevelModifier { get; set; }
	public string Name { get; set; }

	private int CalculateExpTolevel()
	{
		return (int)(ExpToLevel * LevelModifier);
	}

	public void LevelUp()
	{
		ExpToLevel = CalculateExpTolevel();
		BaseValue++;
	}

	public int AdjustedBaseValue
	{
		get { return BaseValue + BuffValue; }
	}
}
