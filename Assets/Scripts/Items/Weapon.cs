public class Weapon : BuffItem 
{
	private int _maxDamage;
	private float _damageVariable;
	private float _maxRange;
	private DamageType _damageType;

	public Weapon()
	{
		_maxDamage = 0;
		_damageVariable = 0f;
		_maxRange = 0f;
		_damageType = DamageType.Bludgeon;
	}

	public Weapon(int maxDamage, float damageVariable, float maxRange, DamageType damageType)
	{
		_maxDamage = maxDamage;
		_damageVariable = damageVariable;
		_maxRange = maxRange;
		_damageType = damageType;
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