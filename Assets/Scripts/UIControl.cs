using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

	public Text debugText1;
	public Text debugText2;
	public GameObject player;
	public GameObject eventSystem;
	private physicsObject playerScript;
	private castPointController castPointScript;
	void Start ()
	{
		playerScript = player.GetComponent<physicsObject>();
		castPointScript = eventSystem.GetComponent<castPointController>();
	}


	void Update ()
	{
		//debugText1.text = "Move Direction: " + playerScript.getDebugData().ToString("G4");
		//debugText2.text = playerScript.getDebugData2().ToString();
	}

	
}
