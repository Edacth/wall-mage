using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicsObject : MonoBehaviour {

	public float minGroundNormalY = 0.65f;
	public float gravityModifier = 1f;
	public GameObject eventSystem;
	

	protected Vector2 targetVelocity;
	protected bool grounded;
	protected Vector2 groundNormal;

	protected Rigidbody2D rb2d;
	protected Vector2 velocity;
	protected ContactFilter2D contactFilter;
	protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
	protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

	protected const float minMoveDistance = 0.001f;
	protected const float shellRadius = 0.01f;

	private UIControl uicontrol;

	private void OnEnable()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start ()
	{
		contactFilter.useTriggers = false;
		contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
		contactFilter.useLayerMask = true;

		uicontrol = eventSystem.GetComponent<UIControl>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		targetVelocity = Vector2.zero;
		ComputeVelocity();
		//Debug.Log("Update");
	}

	protected virtual void ComputeVelocity()
	{

	}

	void FixedUpdate()
	{
		//Debug.Log("Fixed Update");
		velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
		velocity.x = targetVelocity.x;

		grounded = false;

		Vector2 deltaPosition = velocity * Time.deltaTime;

		Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

		Vector2 move = moveAlongGround * deltaPosition.x;

		Movement(move, false);

		move = Vector2.up * deltaPosition.y;

		Movement(move, true);
	}

	void Movement(Vector2 move, bool yMovement)
	{
		//Debug.Log(move.ToString("G4"));
		float distance = move.magnitude;
		if (distance > minMoveDistance)
		{
			int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
			hitBufferList.Clear();
			for (int i = 0; i < count; i++)
			{
				hitBufferList.Add(hitBuffer[i]);

			}
			
			for (int i = 0; i < hitBufferList.Count; i++) //Iterate through our hit list
			{
				Vector2 currentNormal = hitBufferList[i].normal; //CurrentNormal is the hit currently being evaluated
				if (currentNormal.y > minGroundNormalY) //Makes sure the "angle" of the surface is above .65 aka standable
				{
					grounded = true; //Sets grounded to true
					if (yMovement) //If this movement call is in the vertical...
					{
						groundNormal = currentNormal; //Set our normalized "ground level" to the entry in the list
						currentNormal.x = 0; //Negate any x movement
					}
				}
				
				/*
				float projection = Vector2.Dot(velocity, currentNormal); 
				uicontrol.setText1(projection);
				uicontrol.setText2(velocity);
				uicontrol.setText3(currentNormal);
				if (projection < 0)
				{
					velocity = velocity - projection * currentNormal;
				}
				*/
				float modifiedDistance = hitBufferList[i].distance - shellRadius;
				distance = modifiedDistance < distance ? modifiedDistance : distance;
				
			}
		}
		rb2d.position = rb2d.position + move.normalized * distance;
	}


}
