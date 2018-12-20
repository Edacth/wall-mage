using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour
{
	public float speed = 6.0f;
	public float jumpSpeed = 6.0f;
	public float gravity = 30.0f;
	public float fallMultiplier = 2.0f;

	private CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;

	void Start ()
	{
		controller = GetComponent<CharacterController>();
	}
	
	void Update ()
	{
        
		moveDirection.x = Input.GetAxis("Horizontal"); //Get horizontal input
		moveDirection.x *= speed; //Multiply movement by speed


		if (controller.isGrounded) //If grounded
		{
			moveDirection.y = 0.0f; //Set y movement to 0.0
			if (Input.GetButton("Jump")) //Get jump input
			{
				moveDirection.y = jumpSpeed; //Add jump velocity
			}
		}


		
		if (moveDirection.y < 0) //If falling
		{
			moveDirection.y += (gravity * fallMultiplier * Time.deltaTime); //Apply gravity
		}
		else
		{
			moveDirection.y += (gravity * Time.deltaTime); //Apply gravity
		}

		controller.Move(moveDirection * Time.deltaTime); //Move the character
        
	}

	public Vector3 getMoveDirection()
	{
		return moveDirection;
	}
}

