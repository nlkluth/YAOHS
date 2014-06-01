using UnityEngine;
using System.Collections;

public class GameTime : MonoBehaviour 
{
	public Transform[] sun;
	private Sun[] _sun;
	public float dayCycleInMinutes = 1;
	public float StartTime;

	private float dayCycleInSeconds;
	private const float SECOND = 1;
	private const float MINUTE = 60 * SECOND;
	private const float HOUR = 60 * MINUTE;
	private const float DAY = 24 * HOUR;
	private const float DEGREES_PER_SECOND = 360 / DAY;

	private float _degreeRotation;
	private float _timeOfDay;

	void Start()
	{
		dayCycleInSeconds = dayCycleInMinutes * MINUTE;
		_sun = new Sun[sun.Length];

		RenderSettings.skybox.SetFloat("_Blend", 0);

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
		_degreeRotation = DEGREES_PER_SECOND * DAY / dayCycleInSeconds;
	}
	
	void Update () 
	{
		for (int count = 0; count < sun.Length; count++)
		{
			sun[count].Rotate(new Vector3(_degreeRotation, 0, 0) * Time.deltaTime);
			_timeOfDay += Time.deltaTime;
		}

		if (_timeOfDay > dayCycleInSeconds)
		{
			_timeOfDay -= dayCycleInSeconds;
		}

		Debug.Log(_timeOfDay);
		BlendSkybox();

	}

	private void BlendSkybox()
	{
		float temp = _timeOfDay / dayCycleInSeconds * 2;
		if (temp > 1) 
		{
			temp = 1 - (temp - 1);
		}
		RenderSettings.skybox.SetFloat("_Bland", temp);
	}
}
