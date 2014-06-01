using UnityEngine;
using System.Collections;

public class GameTime : MonoBehaviour 
{
	public Transform[] sun;
	private Sun[] _sun;
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
		_sun = new Sun[sun.Length];

		for (int count = 0; count < _sun.Length; count++)
		{
			Sun temp = sun[count].GetComponent<Sun>();

			if (temp == null)
			{
				sun[count].gameObject.AddComponent<Sun>();
				temp = sun[count].GetComponent<Sun>();
			}
			_sun[count] = temp;
		}

		_timeOfDay = 0;
		_degreeRotation = DEGREES_PER_SECOND * DAY / (dayCycleInMinutes * MINUTE);
	}
	
	void Update () 
	{
		for (int count = 0; count < sun.Length; count++)
		{
			sun[count].Rotate(new Vector3(_degreeRotation, 0, 0) * Time.deltaTime);
			_timeOfDay += Time.deltaTime;
		}

	}
}
