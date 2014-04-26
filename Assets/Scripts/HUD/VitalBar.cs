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
	{
		if (_isPlayerHealthBar) {
			Messenger<float>.AddListener ("player health update", OnHealthBarChanged);
		} else {
			Messenger<float>.AddListener ("mob health update", OnHealthBarChanged);
		}
	}

	public void OnDisable()
	{
		if (_isPlayerHealthBar) {
			Messenger<float>.RemoveListener ("player health update", OnHealthBarChanged);
		} else {
			Messenger<float>.RemoveListener ("mob health update", OnHealthBarChanged);
		}
	}

	public void OnHealthBarChanged(int maxHealth, int currentHealth)
	{

	}

	public void SetPlayerHealthBar(bool flag)
	{
		_isPlayerHealthBar = flag;
	}
}
