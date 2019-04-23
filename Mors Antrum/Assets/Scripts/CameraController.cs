using UnityEngine;

public class CameraController : MonoBehaviour
{
        
	public Transform target;  //the player
	public Vector3 offset = new Vector3(0f,0f,-8.5f);  //how far from them the player the camera is

	public float boundX; //used to clamp the x variable
	public float boundY; //used to clamp the y variable

    public GameObject objTop;
    public GameObject objBottom;
    public GameObject objLeft;
    public GameObject objRight;

    private float camTop;
    private float camBottom;
    private float camLeft;
    private float camRight;

    public float offsetX = 4.5f;
    public float offsetY = 3.2f;


	public float smoothSpeed = 0.125f;  //used to make the camera movement speed

	private void Awake()
	{
		//sets the cam... vectors using their GameObjects, thisll keep the Clamp script neater
		camTop = objTop.transform.position.y;
		camBottom = objBottom.transform.position.y;
		camLeft = objLeft.transform.position.x;
		camRight = objRight.transform.position.x;
	}


	private void FixedUpdate()
	{
		//set the clamps (this makes sure the camera doesn't go outside the map walls)
		boundX = target.position.x;
		boundY = target.position.y;
		
		boundX = (Mathf.Clamp(boundX, camLeft + offsetX, camRight - offsetX));
		boundY = (Mathf.Clamp(boundY, camBottom + offsetY, camTop - offsetY));
		
		//set the desiredPosition - this is where the camera wants to be, then sends the smoothPosition - this makes the camera move smoothly towards the position
		Vector3 desiredPosition = new Vector3(boundX, boundY, target.position.z) + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);  
		
		transform.position = (smoothedPosition);
	}
}
