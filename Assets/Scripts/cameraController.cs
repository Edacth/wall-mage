using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
	public GameObject player;
	public Vector3 offset;

	void Start()
	{
		
	}

	private void Update()
	{
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y) + offset;
	}


}
