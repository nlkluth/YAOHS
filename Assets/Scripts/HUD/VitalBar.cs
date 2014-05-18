using UnityEngine;
using System.Collections;

public class VitalBar : MonoBehaviour {
	public bool _isPlayerHealthBar;
	private int _maxBarLength;
	private int _currentBarLength;
	private GUITexture _display;

	void Awake()
	{
		_display = gameObject.GetComponent<GUITexture> ();
	}

	void Start () 
	{
		_maxBarLength = (int)_display.pixelInset.width;
		_currentBarLength = _maxBarLength;
		_display.pixelInset = CalculatePosition();
		OnEnable();
	}
	
	void Update () 
	{}

	public void OnEnable()
	{
		if (_isPlayerHealthBar) {
			Messenger<int, int>.AddListener("player health update", OnHealthBarChanged);
		} else {
			ToggleDisplay(false);
			Messenger<int, int>.AddListener("mob health update", OnHealthBarChanged);
			Messenger<bool>.AddListener("show mob vitalbars", ToggleDisplay);
		}
	}

	public void OnDisable()
	{
		if (_isPlayerHealthBar) {
			Messenger<int, int>.RemoveListener("player health update", OnHealthBarChanged);
		} else {
			Messenger<int, int>.RemoveListener("mob health update", OnHealthBarChanged);
			Messenger<bool>.RemoveListener("show mob vitalbars", ToggleDisplay);
		}
	}

	public void OnHealthBarChanged(int maxHealth, int currentHealth)
	{
		_currentBarLength = (int)((currentHealth / (float)maxHealth) * _maxBarLength);
		_display.pixelInset = CalculatePosition();
	}

	public void SetPlayerHealthBar(bool flag)
	{
		_isPlayerHealthBar = flag;
	}

	public Rect CalculatePosition() 
	{
		float yPos = _display.pixelInset.y / 2 - 10;

		if (!_isPlayerHealthBar)
		{
			float xPos = (_maxBarLength - _currentBarLength) - (_maxBarLength / 4 + 10);
			return new Rect(xPos, yPos, _currentBarLength, _display.pixelInset.height);
		}

		return new Rect(_display.pixelInset.x, yPos, _currentBarLength, _display.pixelInset.height);
	}

	private void ToggleDisplay(bool show)
	{
		_display.enabled = show;
	}
}
