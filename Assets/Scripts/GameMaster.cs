using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour 
{
	public GameObject playerCharacter;
	public Camera mainCamera;

	void Start() 
	{
		Instantiate (playerCharacter, Vector3.zero, Quaternion.identity);
	}
	
	void Update()
	{
	
	}
}
