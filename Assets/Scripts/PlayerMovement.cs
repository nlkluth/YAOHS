using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float moveSpeed = 0.1f;
	public float maxSpeed = 10f;
	public float speedSmooth = 0.4f;
	
	void FixedUpdate()
	{
		float movement = Input.GetAxis("Horizontal") * moveSpeed;
		if (movement > 0) {
			MoveCharacter(movement);
		}
	}
	
	void MoveCharacter(float movement)
	{
        transform.Translate(0f, 0f, movement);
	}
}
