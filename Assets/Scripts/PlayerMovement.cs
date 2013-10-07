using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float moveSpeed = 0.1f;
	public float minSpeed = 0.2f;
	public float maxSpeed = 0.5f;
	public float damper = 0.6f;
	public float backPedalSpeed = -0.1f;
	
	private bool decelerating = false;
	
	void FixedUpdate()
	{	
		CheckInput();
		
		if (decelerating)
			SlowCharacterDown();
	}
	
	void CheckInput()
	{
		if (Input.GetAxisRaw("Horizontal") == 1)
		{
			decelerating = false;
			MoveCharacter();
		}
		
		if (Input.GetAxisRaw("Horizontal") == -1)
			BackPedal();
		
		if (Input.GetButtonUp("Horizontal"))
			decelerating = true;
		
		if (Input.GetButtonDown("Jump"))
			Jump();
	}
	
	void MoveCharacter()
	{	
		moveSpeed += moveSpeed * Time.deltaTime;
		
		if (moveSpeed < maxSpeed)
			transform.Translate(0f, 0f, moveSpeed);
		else
			transform.Translate(0f, 0f, maxSpeed);
	}
	
	void BackPedal()
	{
		transform.Translate(0f, 0f, backPedalSpeed);
	}
	
	void SlowCharacterDown()
	{
		moveSpeed -= moveSpeed * (Time.deltaTime * damper);
		transform.Translate(0f, 0f, moveSpeed);
		
		if (moveSpeed < minSpeed)
			decelerating = false;
	}
	
	void Jump()
	{}
}