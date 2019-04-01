using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

	public Text debugText1;
	public Text debugText2;
	public Text debugText3;
	public GameObject player;
	public GameObject eventSystem;
	private physicsObject playerScript;
	private castPointController castPointScript;
	string text1;
	string text2;
	string text3;
	void Start ()
	{
		playerScript = player.GetComponent<physicsObject>();
		castPointScript = eventSystem.GetComponent<castPointController>();
	}


	void Update ()
	{
		debugText1.text = text1;
		debugText2.text = text2;
		debugText3.text = text3;
	}

	public void setText1(float data)
	{
		text1 = data.ToString("G4");
	}

	public void setText2(Vector2 data)
	{
		text2 = data.ToString("G4");
	}

	public void setText3(Vector2 data)
	{
		text3 = data.ToString("G4");
	}
}
