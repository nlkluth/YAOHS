using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Targetting : MonoBehaviour 
{
	public List<Transform> targets;
	public Transform selectedTarget;

	void Start() 
	{
		targets = new List<Transform>();
		selectedTarget = null;

		AddAllTargets();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
	    {
			TargetEnemy();
		}
	}

	public void AddAllTargets()
	{
		GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");

		foreach (GameObject target in targets)
		{
			AddTarget(target.transform);
		}
	}

	public void AddTarget(Transform target)
	{
		targets.Add(target);
	}

	private void TargetEnemy()
	{
		selectedTarget = targets[0];
	}
}
