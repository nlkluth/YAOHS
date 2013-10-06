using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float moveSpeed = 0.1f;
	public float minSpeed = 0.2f;
	public float maxSpeed = 0.5f;
	public float damper = 0.6f;
	
	private bool decelerating = false;
	
	void FixedUpdate()
	{	
		if (Input.GetButton("Horizontal"))
		{
			decelerating = false;
			MoveCharacter();
		}
		
		if (Input.GetButtonUp("Horizontal"))
			decelerating = true;
		
		if (decelerating)
			SlowCharacterDown();
	}
	
	void MoveCharacter()
	{
		moveSpeed += moveSpeed * Time.deltaTime;
		
		if (moveSpeed < maxSpeed)
			transform.Translate(0f, 0f, moveSpeed);
		else
			transform.Translate(0f, 0f, maxSpeed);
	}
	
	void SlowCharacterDown()
	{
		moveSpeed -= moveSpeed * (Time.deltaTime * damper);
		transform.Translate(0f, 0f, moveSpeed);
		
		if (moveSpeed < minSpeed)
			decelerating = false;
	}
}