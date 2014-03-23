
public class Attribute : BaseStat
{
	public Attribute()
	{
		ExpToLevel = 50;
		LevelModifier = 1.05f;
	}

	public enum AttributeName
	{
		Might,
		Consitution,
		Nimbleness,
		Speed,
		Concentration,
		Willpower,
		Charisma
	}
}
