using UnityEngine;
using System.Collections;

public class VitalBar : MonoBehaviour {
	public bool _isPlayerHealthBar;
	private int _maxBarLength;
	private int _currentBarLength;
	private GUITexture _display;

	void Start () 
	{
//		_isPlayerHealthBar = true;
		_display = gameObject.GetComponent<GUITexture> ();

		_maxBarLength = (int)_display.pixelInset.width;

		OnEnable();
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
		_currentBarLength = (int)((currentHealth / (float)maxHealth) * _maxBarLength);
		_display.pixelInset = new Rect(_display.pixelInset.x, _display.pixelInset.y, _currentBarLength, _display.pixelInset.height);
	}

	public void SetPlayerHealthBar(bool flag)
	{
		_isPlayerHealthBar = flag;
	}
}
