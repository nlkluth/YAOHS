using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float moveSpeed = 0.1f;
	public float maxSpeed = 10f;
	
	void FixedUpdate()
	{
		if (Input.GetButton("Horizontal") && moveSpeed < maxSpeed)
		{
			MoveCharacter();
		}
	}
	
	void MoveCharacter()
	{
		moveSpeed += moveSpeed * Time.deltaTime;
		transform.Translate (0f, 0f, moveSpeed);
	}
}
