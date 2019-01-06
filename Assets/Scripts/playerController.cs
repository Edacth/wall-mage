using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : physicsObject
{
	public float speed = 6.0f;
	public float jumpSpeed = 6.0f;

	private SpriteRenderer spriteRenderer;

	void Awake ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	protected override void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxis("Horizontal");

		if (Input.GetButtonDown("Jump") && grounded)
		{
			velocity.y = jumpSpeed;
		}
		else if (Input.GetButtonUp("Jump"))
		{
			if (velocity.y > 0)
			{
				velocity.y = velocity.y * 0.5f;
			}
		}

		targetVelocity = move * speed;
	}

	/*public Vector3 getDebugData()
	{
		return moveDirection;
	}

	public bool getDebugData2()
	{
		return isGrounded();
	}*/

}

