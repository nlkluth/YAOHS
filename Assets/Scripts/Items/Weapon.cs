public class Weapon : BuffItem 
{
	private int MaxDamage { get; set; }
	private float DamageVariable { get; set; }
	private float MaxRange { get; set; }
	private DamageType DamageType { get; set; }

	public Weapon()
	{
		MaxDamage = 0;
		DamageVariable = 0f;
		MaxRange = 0f;
		DamageType = DamageType.Bludgeon;
	}

	public Weapon(int maxDamage, float damageVariable, float maxRange, DamageType damageType)
	{
		MaxDamage = maxDamage;
		DamageVariable = damageVariable;
		MaxRange = maxRange;
		DamageType = damageType;
	}
}

public enum DamageType
{
	Bludgeon,
	Pierce,
	Slash,
	Fire,
	Ice,
	Lightning,
	Acid
}