
public class Attribute : BaseStat
{
	public Attribute()
	{
		Name = "";
		ExpToLevel = 50;
		LevelModifier = 1.05f;
	}

	public string Name { get; set; }
}

public enum AttributeName
{
	Might,
	Constitution,
	Nimbleness,
	Speed,
	Concentration,
	Willpower,
	Charisma
}
