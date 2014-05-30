using UnityEngine;
using System.Collections;

public class GameTime : MonoBehaviour 
{
	public Transform[] sun;
	public float dayCycleInMinutes = 1;

	private const float SECOND = 1;
	private const float MINUTE = 60 * SECOND;
	private const float HOUR = 60 * MINUTE;
	private const float DAY = 24 * HOUR;
	private const float DEGREES_PER_SECOND = 360 / DAY;

	private float _degreeRotation;
	private float _timeOfDay;

	void Start()
	{
		_timeOfDay = 0;
		_degreeRotation = DEGREES_PER_SECOND * DAY / (dayCycleInMinutes * MINUTE);
	}
	
	void Update () 
	{
		sun[0].Rotate(new Vector3(_degreeRotation, 0, 0) * Time.deltaTime);
		_timeOfDay += Time.deltaTime;
	}
}
