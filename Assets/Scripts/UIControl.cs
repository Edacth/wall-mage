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
		Resolution[] resolutions = Screen.resolutions;
		Debug.Log(resolutions[1].height.ToString());
	}


	void Update ()
	{
		debugText1.text = castPointScript.getMouseMovment().ToString();
		debugText2.text = castPointScript.getScreenInUnits().x.ToString("G4");
	}

	
}
