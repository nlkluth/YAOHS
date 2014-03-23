public class Skill : BaseStat 
{
	public Skill()
	{
		Known = false;
		ExpToLevel = 25;
		LevelModifier = 1.1f;
	}

	public bool Known { get; set; }
}

public enum SkillName
{
	Melee_Offense,
	Melee_Defense,
	Ranged_Offense,
	Ranged_Defense,
	Magic_Offense,
	Magic_Defense
}