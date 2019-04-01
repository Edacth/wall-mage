using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castPointController : MonoBehaviour {

	public GameObject player;
	public GameObject castPoint;
	public Camera camera;
	public float sensitivity = 0.4f;

    BoxCollider2D boxCollider;
	private playerController playerScript;
	private cameraController cameraScript;
	private Vector2 mousePosition;
	private Vector2 previousMousePositon;
	private float screenHeightInUnits;
	private float screenWidthInUnits;
	private float unitPerPixel;
    private float leftBound, rightBound, topBound, bottomBound;

	void Start ()
	{
		playerScript = player.GetComponent<playerController>();
		cameraScript = camera.GetComponent<cameraController>();
        boxCollider = castPoint.GetComponent<BoxCollider2D>();
		castPoint.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, player.transform.position.z);
		mousePosition = Input.mousePosition;
		previousMousePositon = Input.mousePosition;
		screenHeightInUnits = camera.orthographicSize * 2;
		screenWidthInUnits = screenHeightInUnits * ((float)Screen.width / (float)Screen.height);
		unitPerPixel = screenHeightInUnits / Screen.height;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
	{
        leftBound = camera.transform.position.x - screenWidthInUnits / 2;
        rightBound = camera.transform.position.x + screenWidthInUnits / 2;
        topBound = camera.transform.position.y + screenHeightInUnits / 2;
        bottomBound = camera.transform.position.y - screenHeightInUnits / 2;

        Vector2 mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 movement = new Vector2(mouseMovement.x * sensitivity, mouseMovement.y * sensitivity);
		Vector2 newPosition = new Vector3(castPoint.transform.position.x + movement.x, castPoint.transform.position.y + movement.y, 0);
        
        if ( (newPosition.x - boxCollider.size.x / 2 < leftBound) || (newPosition.x + boxCollider.size.x / 2 > rightBound ) )
		{
            newPosition.x = Mathf.Clamp(newPosition.x, leftBound + boxCollider.size.x / 2, rightBound - boxCollider.size.x / 2);
        }
        if ((newPosition.y - boxCollider.size.y / 2 < bottomBound) || (newPosition.y + boxCollider.size.x / 2 > topBound))
        {
            newPosition.y = Mathf.Clamp(newPosition.y, bottomBound + boxCollider.size.y / 2, topBound - boxCollider.size.y / 2);
        }

        castPoint.transform.position = newPosition;

        if (Input.GetMouseButtonDown(0))
        {

        }
    }

}
