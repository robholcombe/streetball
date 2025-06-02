using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {
	
    //Public Variables
    [Header("Camera Variables")]
	public Transform camTarget;
    public int camFOV = 40; //set to 35 for more broadcast zoom


    //Private Variables
    private float smooth;
    private Vector3 targetPos;
	private float damping = 1f;
	

    //On Startup
	void Awake()
	{

        //Get camera target object (this is the game ball)
		camTarget = GameObject.FindWithTag ("Ball").transform;
		
	}


	//Late update used for all movement to ensure smooth camera operation (after physics and update movements are applied).
	void LateUpdate()
	{
		//Set positions
		targetPos = camTarget.position;
		targetPos.y = camTarget.position.y;
		targetPos.z = 15;

		//Offset camera (based on the player being on the left)
		targetPos.x = camTarget.position.x - 5;
		//Set field of view (this is an idea distance for the camera position)
		this.GetComponent<Camera>().fieldOfView = camFOV;

		//Set rotation and quaternion slerp rotation to player position
		var rotation = Quaternion.LookRotation(targetPos - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
		
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
