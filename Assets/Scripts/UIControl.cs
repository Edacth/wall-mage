using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

	public Text debugText1;
	public Text debugText2;
	public GameObject player;
	public GameObject eventSystem;
	private playerController playerScript;
	private castPointController castPointScript;
	void Start ()
	{
		playerScript = player.GetComponent<playerController>();
		castPointScript = eventSystem.GetComponent<castPointController>();
	}


	void Update ()
	{
		debugText1.text = "Mouse Movement: " + castPointScript.getMouseMovement().ToString("G4");
		debugText2.text = "Object Position: " + castPointScript.getCastPointPosition().ToString("G4");
	}

	
}
