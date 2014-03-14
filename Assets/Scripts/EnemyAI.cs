using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	public Transform target;
	public float moveSpeed;
	public float rotationSpeed;
	public float maxDistance;

	private Transform localTransform;

	void Awake()
	{
		localTransform = transform;
	}

	void Start () 
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		target = player.transform;
		maxDistance = 2f;
	}
	
	void Update () 
	{
		localTransform.rotation = Quaternion.Slerp(localTransform.rotation, Quaternion.LookRotation(target.position - localTransform.position), rotationSpeed * Time.deltaTime);

		if (Vector3.Distance(target.position, localTransform.position) > maxDistance)
		{
			localTransform.position += localTransform.forward * moveSpeed * Time.deltaTime;
		}
	}
}
