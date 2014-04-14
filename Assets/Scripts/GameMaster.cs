using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour 
{
	public GameObject playerCharacter;
	public Camera mainCamera;

	private GameObject player;

	void Start() 
	{
		player = Instantiate (playerCharacter, Vector3.zero, Quaternion.identity) as GameMaster;

		mainCamera.transform.position = player.transform.position;
	}
	
	void Update()
	{
	
	}
}
