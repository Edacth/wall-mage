using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castPointController : MonoBehaviour {

	public GameObject player;
	public GameObject castPoint;
	public Camera camera;
	private playerController playerScript;
	private cameraController cameraScript;
	private Vector2 mousePosition;
	private Vector2 previousMousePositon;
	private Vector2 mouseMovement;
	float screenHeightInUnits;
	float screenWidthInUnits;
	float unitPerPixel;

	void Start ()
	{
		playerScript = player.GetComponent<playerController>();
		cameraScript = camera.GetComponent<cameraController>();
		castPoint.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, player.transform.position.z);
		mousePosition = Input.mousePosition;
		previousMousePositon = Input.mousePosition;
		screenHeightInUnits = camera.orthographicSize * 2;
		screenWidthInUnits = screenHeightInUnits * ((float)Screen.width / (float)Screen.height);
		unitPerPixel = screenHeightInUnits / Screen.height;
		Debug.Log(Input.mousePosition.ToString("G4"));
		Debug.Log((Input.mousePosition * unitPerPixel).ToString("G4"));
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
	{
		/*Shit Trig System*/
		{/*
		float adjacent = Mathf.Abs(cameraScript.offset.z);
		mouseRay = camera.ScreenPointToRay((Input.mousePosition));
		xAngle = -(Mathf.Atan2(mouseRay.direction.z, mouseRay.direction.x) - Mathf.Atan2(1, 0));
		float opposite = xAngle * adjacent;
		float hypotenuse = Mathf.Sqrt(Mathf.Pow(adjacent, 2) + Mathf.Pow(opposite, 2) );

		castPoint.transform.position = new Vector3(mouseRay.origin.x + opposite, mouseRay.origin.y, mouseRay.origin.z + 10);

		Debug.DrawLine(mouseRay.origin, mouseRay.GetPoint(hypotenuse), Color.blue);
		Debug.DrawRay(mouseRay.origin, new Vector3(0, 0, adjacent), Color.red);
		Debug.DrawLine(new Vector3(mouseRay.origin.x, mouseRay.origin.y, mouseRay.origin.z + adjacent),
			new Vector3(mouseRay.origin.x + opposite, mouseRay.origin.y, mouseRay.origin.z + adjacent), Color.green);
		*/
		}

        /*Cool Ortho System*/
        {/*
		mousePosition = Input.mousePosition;
        mouseMovement = (mousePosition - previousMousePositon);
        mouseMovement.x *= unitPerPixel;
        mouseMovement.y *= unitPerPixel;
        previousMousePositon = mousePosition;
        castPoint.transform.position = new Vector3(castPoint.transform.position.x + mouseMovement.x, castPoint.transform.position.y + mouseMovement.y, 0);
        */}

        mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        
        mouseMovement.x *= 0.4f;
        mouseMovement.y *= 0.4f;
		castPoint.transform.position = new Vector3(castPoint.transform.position.x + mouseMovement.x, castPoint.transform.position.y + mouseMovement.y, 0);
    }

	public Vector2 getCastPointPosition()
	{
		return castPoint.transform.position;
	}

	public Vector2 getMouseMovement()
	{
		return mouseMovement;
	}
}
