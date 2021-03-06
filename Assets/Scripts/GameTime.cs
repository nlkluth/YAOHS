﻿using UnityEngine;
using System.Collections;

public class GameTime : MonoBehaviour 
{
	public enum TimeOfDay 
	{
		Idle,
		SunRise,
		SunSet
	}

	public Transform[] sun;
	private Sun[] _sun;
	public float dayCycleInMinutes = 1;
	public float sunRise;
	public float sunSet;
	public float skyBoxBlendModifier;
	public Color ambientLightMin;
	public Color ambientLightMax;

	private float dayCycleInSeconds;
	private TimeOfDay _tod;
	private const float SECOND = 1;
	private const float MINUTE = 60 * SECOND;
	private const float HOUR = 60 * MINUTE;
	private const float DAY = 24 * HOUR;
	private const float DEGREES_PER_SECOND = 360 / DAY;

	private float _degreeRotation;
	private float _timeOfDay;
	private float _noonTime;
	private float _morningLength;
	private float _eveningLength;

	void Start()
	{
		dayCycleInSeconds = dayCycleInMinutes * MINUTE;
		_tod = TimeOfDay.Idle;
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

		sunRise *= dayCycleInSeconds;
		sunSet += dayCycleInSeconds;
		_noonTime = dayCycleInSeconds / 2;
		_morningLength = _noonTime - sunRise;
		_eveningLength = sunSet - _noonTime;

		SetupLighting();
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

		if (_timeOfDay > sunRise && _timeOfDay < _noonTime) 
		{
			AdjustLighting(true);
		}

		else if (_timeOfDay > _noonTime && _timeOfDay < sunSet)
		{
			AdjustLighting(false);
		}

		if (_timeOfDay > sunRise && _timeOfDay < sunSet && RenderSettings.skybox.GetFloat("_Blend") < 1) 
		{
			BlendSkybox();
			_tod = TimeOfDay.SunRise;
		}
		else if (_timeOfDay > sunSet && RenderSettings.skybox.GetFloat("_Blend") > 0)
		{
			_tod = TimeOfDay.SunSet;
			BlendSkybox();
		}

		else
		{
			_tod = TimeOfDay.Idle;
		}

	}

	private void BlendSkybox()
	{
		float temp = 0;

		switch (_tod) 
		{
		case TimeOfDay.SunRise:
			temp = (_timeOfDay - sunRise) / skyBoxBlendModifier;
			break;
		case TimeOfDay.SunSet:
			temp = (_timeOfDay = sunSet) / skyBoxBlendModifier;
			temp = 1 - temp;
			break;
		}

		RenderSettings.skybox.SetFloat("_Blend", temp);
	}

	private void SetupLighting()
	{
		RenderSettings.ambientLight = ambientLightMin;

		for (int count = 0; count < _sun.Length; count++)
		{
			if(_sun[count].givesLight)
			{
				_sun[count].GetComponent<Light>().intensity = _sun[count].minLightBrightness;
			}
		}
	}

	private void AdjustLighting(bool brighten)
	{
		float position = 0;

		if (brighten) 
		{
			position = (_timeOfDay - sunRise) / _morningLength;
		}
		else
		{
			position = (sunSet - _timeOfDay) / _eveningLength;
		}

		RenderSettings.ambientLight = new Color(ambientLightMin.r + ambientLightMax.r * position,
		                                        ambientLightMin.g + ambientLightMax.g * position,
		                                        ambientLightMin.b + ambientLightMax.b * position);

		for (int count = 0; count < _sun.Length; count++)
		{
			if (_sun[count].givesLight)
			{
				_sun[count].GetComponent<Light>().intensity = _sun[count].maxLightBrightness * position;
			}
		}
	}
}
