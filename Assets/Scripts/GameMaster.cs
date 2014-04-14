using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour 
{
	public GameObject playerCharacter;

	void Start() 
	{
		Instantiate (playerCharacter, Vector3.zero, Quaternion.identity);
	}
	
	void Update()
	{
	
	}
}
