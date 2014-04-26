using UnityEngine;
using System.Collections;

public class VitalBar : MonoBehaviour {
	public bool _isPlayerHealthBar;
	private int _maxBarLength;

	void Start () 
	{
		_isPlayerHealthBar = true;
	}
	
	void Update () 
	{}

	public void OnEnable()
	{
		if (_isPlayerHealthBar) {
			Messenger<int, int>.AddListener("player health update", OnHealthBarChanged);
		} else {
			Messenger<int, int>.AddListener("mob health update", OnHealthBarChanged);
		}
	}

	public void OnDisable()
	{
		if (_isPlayerHealthBar) {
			Messenger<int, int>.RemoveListener("player health update", OnHealthBarChanged);
		} else {
			Messenger<int, int>.RemoveListener("mob health update", OnHealthBarChanged);
		}
	}

	public void OnHealthBarChanged(int maxHealth, int currentHealth)
	{
		Debug.Log("Heard event");
	}

	public void SetPlayerHealthBar(bool flag)
	{
		_isPlayerHealthBar = flag;
	}
}
