using UnityEngine;
using System.Collections;

public class VitalBar : MonoBehaviour {
	private bool _isPlayerHealthBar;

	void Start () 
	{
		_isPlayerHealthBar = true;
	}
	
	void Update () 
	{}

	public void OnEnable()
	{}

	public void OnDisable()
	{}

	public void ChangeHealthBarSize(int maxHealth, int currentHealth)
	{

	}

	public void SetPlayerHealthBar(bool flag)
	{
		_isPlayerHealthBar = flag;
	}
}
