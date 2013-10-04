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
			float speed = Mathf.Lerp(movement, maxSpeed, speedSmooth * Time.deltaTime);
        	transform.Translate(0f, 0f, speed);
			
		}
	}
}
