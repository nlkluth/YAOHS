﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float moveSpeed = 0.1f;
	public float maxSpeed = 0.5f;
	
	void FixedUpdate()
	{	
		if (Input.GetButton("Horizontal"))
			MoveCharacter();
		
		if (Input.GetButtonUp("Horizontal"))
			moveSpeed = 0.1f;
	}
	
	void MoveCharacter()
	{
		moveSpeed += moveSpeed * Time.deltaTime;
		
		if (moveSpeed < maxSpeed)
			transform.Translate(0f, 0f, moveSpeed);
		else
			transform.Translate(0f, 0f, maxSpeed);
	}
}
