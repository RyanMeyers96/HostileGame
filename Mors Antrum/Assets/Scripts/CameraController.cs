using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
        
	public Transform target;  //the player
	public Vector3 offset = new Vector3(0f,0f,-7f);  //how far from them the player the camera is

	public float boundX; //used to clamp the x variable
	public float boundY; //used to clamp the y variable
	
	public float smoothSpeed = 0.125f;  //used to make the camera movement speed

	private void FixedUpdate()
	{
		//set the clamps (this makes sure the camera doesn't go outside the map walls)
		boundX = target.position.x;
		boundY = target.position.y;
		
		boundX = (Mathf.Clamp(boundX, -4f, 4f));
		boundY = (Mathf.Clamp(boundY, -1f, 30f));
		
		//set the desiredPosition - this is where the camera wants to be, then sends the smoothPosition - this makes the camera move smoothly towards the position
		Vector3 desiredPosition = new Vector3(boundX, boundY, target.position.z) + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);  
		
		transform.position = (smoothedPosition);
	}
}
