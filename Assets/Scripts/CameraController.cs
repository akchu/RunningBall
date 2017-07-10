using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	private Transform lookAt;
	private Vector3 startOffset;
	private Vector3 moveVector;

	private float transition = 0.0f;
	private float animDuration = 6.0f;
	private Vector3 animOffset = new Vector3 (0, 5, 5);

	// Use this for initialization
	void Start () 
	{
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
		startOffset = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		moveVector = lookAt.position + startOffset;
		//x
		moveVector.x = 0;

		//y
		moveVector.y = Mathf.Clamp (moveVector.y, 3, 5);

		if (transition > 1.0) 
		{
			transform.position = moveVector;	
		} else {
			//Camera Animation at start of game
			transform.position = Vector3.Lerp (moveVector + animOffset, moveVector, transition);
			transition += Time.deltaTime *2 / animDuration;
			transform.LookAt (lookAt.position + Vector3.up);
		}
	}
}
