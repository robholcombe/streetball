using UnityEngine;
using System.Collections;

public class PlayerMovement : PlayerManager
{
	//Public Variables
    [Header("Current active camera")]
    //holds the main camera as a Transform object for using camera-relative movement calc.
	public Transform mainCamera;

    //Private variables for character movement
    private float moveSpeedAverage = 0.0f;
    private float h = 0.0f;
    private float v = 0.0f;
    private float turnSmoothing = 15f;
    private float speedDampTime = 0.1f;
    
	
	//On Start Method.
    void Start()
    {
        //Initiate camera's transform
		mainCamera = Camera.main.transform;

    //end start method.    	
	}
	
	
	
    //On FixedUpdate, refresh local position variables and cache player inputs. This is fixed updated because it's a rigidbody.
	void FixedUpdate()
	{
        //Cache inputs from user
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        //average speed out for use in MovementManagement function to make walk an option (prevents double speed on diagonal stick input).
        if (h != 0 && v != 0) //if the horizontal and vertical axis have movement, average the two.
        {
            moveSpeedAverage = ((Mathf.Abs(h) + Mathf.Abs(v)) / 2);
        }
        else //else, just use the single axis that has input
        {
            moveSpeedAverage = ((Mathf.Abs(h) + Mathf.Abs(v)) / 1);
        }

        //Call movement function to move player character only if the player is not shooting.
        if (playerAnimator.GetBool(AnimatorHash.shootingBool) == false)
        {
            MovementManagement(h, v, moveSpeedAverage);
        }

    //end FixedUpdate method.
    }




	//Function that controls translation of movement
	void MovementManagement (float horizontal, float vertical, float moveSpeedAverage)
	{
		    //anim.SetBool (hash.SprintingBool, sprinting);
			//check that movement (h&v) is not stationary (not at zero) and set the SpeedFloat
			if (horizontal != 0f || vertical != 0f) {
				Rotating (horizontal, vertical);
                playerAnimator.SetFloat(AnimatorHash.speedFloat, moveSpeedAverage, speedDampTime, Time.deltaTime);
			} else {
                playerAnimator.SetFloat(AnimatorHash.speedFloat, 0f);
			}
			
        /*else
		{
			//If player is shooting, do nothing. This stops movement while in the shooting motion.
		}*/
	}
	

	//Create Rotating function to manage smoothing rotation
	void Rotating(float horizontal, float vertical)
	{
		//get the forward-facing direction of the camera
		Vector3 cameraForward = mainCamera.TransformDirection(Vector3.forward);
		cameraForward.y = 0;    //set to 0 because of camera rotation on the X axis
		//get the right-facing direction of the camera
		Vector3 cameraRight = mainCamera.TransformDirection(Vector3.right);
		//determine the direction the player will face based on input and the camera's right and forward directions
		Vector3 targetDirection = horizontal * cameraRight + vertical * cameraForward;
		//normalize the direction the player should face
		Vector3 lookDirection = targetDirection.normalized;

		Quaternion targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
		Quaternion newRotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation,targetRotation, turnSmoothing * Time.deltaTime);
		GetComponent<Rigidbody>().MoveRotation(newRotation);
	}
    
   
//end of script
}