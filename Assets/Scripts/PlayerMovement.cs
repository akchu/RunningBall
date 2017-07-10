using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{

	private CharacterController controller;	
	private Vector3 moveVector;
	private float VerticalVelocity = 0.0f;
	private float gravity = 9.0f;
	private float speed = 5.0f;
	private float animDuration =3.0f;
	private bool isDead = false;
	private float StartTime;


	// Use this for initialization
	void Start () 
	{
		StartTime = Time.time;
		controller = GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (isDead)
			return;
		
		if (Time.time - StartTime < animDuration) 
		{
			controller.Move (Vector3.forward * speed * Time.deltaTime );
			return;
		}
		moveVector = Vector3.zero;

		if (controller.isGrounded) 
		{
			VerticalVelocity = -0.05f;
		} 
		else 
		{
			VerticalVelocity -= gravity * Time.deltaTime;
		}
		moveVector = Vector3.zero;
		//X
		moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

		//Y
//		moveVector.y = VerticalVelocity;

		//z
		moveVector.z = speed;

		controller.Move (moveVector * Time.deltaTime);	
	}

	public void SetSpeed(float Speedy)
	{
		speed = 5.0f + Speedy;
	}
		
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.gameObject.tag == "Enemy")
			Death ();
	}

	void Death()
	{
		isDead = true;
		GetComponent<ScoreController> ().OnDeath ();
	}



}
