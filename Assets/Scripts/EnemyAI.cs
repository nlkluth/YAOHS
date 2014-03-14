using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	public Transform target;
	public float moveSpeed;
	public float rotationSpeed;

	private Transform localTransform;

	void Awake()
	{
		localTransform = transform;
	}

	void Start () 
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		target = player.transform;
	}
	
	void Update () 
	{
		localTransform.rotation = Quaternion.Slerp(localTransform.rotation, Quaternion.LookRotation(target.position - localTransform.position), rotationSpeed * Time.deltaTime);
		localTransform.position += localTransform.forward * moveSpeed * Time.deltaTime;
	}
}
