using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Targeting : MonoBehaviour 
{
	public List<Transform> targets;
	public Transform selectedTarget;

	private Transform localTransform;

	void Start() 
	{
		targets = new List<Transform>();
		selectedTarget = null;
		localTransform = transform;

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

	private void SortTargetsByDistance()
	{
		targets.Sort(delegate(Transform t1, Transform t2)
		{
			return (Vector3.Distance(t1.position, localTransform.position)
			        .CompareTo(Vector3.Distance(t2.position, localTransform.position)));
		});
	}

	private void TargetEnemy()
	{
		if (selectedTarget == null)
		{
			SortTargetsByDistance();
			selectedTarget = targets[0];
		}
		else
		{
			int index = targets.IndexOf(selectedTarget);

			if (index < targets.Count - 1)
			{
				index++;
			}

			else
			{
				index = 0;
			}

			selectedTarget = targets[index];
			SelectTarget();
		}
	}

	private void SelectTarget()
	{
		selectedTarget.renderer.material.color = Color.red;
	}
}
