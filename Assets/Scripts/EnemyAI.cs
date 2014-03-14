using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	public Transform target;
	public int moveSpeed;

	private Transform localTransform;

	void Awake()
	{
		localTransform = transform;
	}

	void Start () 
	{
		GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () 
	{
	
	}
}
