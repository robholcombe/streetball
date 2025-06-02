using UnityEngine;
using System.Collections;

public class PlayerShoot : PlayerManager
{
    //Private animation variables.
    private Transform shotOffset;
	private Vector3 shotRand;
    private Vector3 shotDirection;
    private int shotRelease;
    private int shotReleaseCheck;
    private int shotStart;
    private int shotSuccess;
    private Vector3 shotSuccessModifier;
    private int shotTiming;
    private float ballSpin = -50f;
    
   

    //On update, check for offensive inputs (shoot,dunk etc) to trigger offensive events.
    private void Update()
    {
        //Start shot function when in possession of the ball and button is pressed down.
        if (playerAnimator.GetBool(AnimatorHash.dribblingBool) == true && shooting == false && Input.GetButtonDown("Jump"))
        {
            shooting = true;
            //set animator bools to perform ball gather (stops dribbling and holds ball).
            playerAnimator.SetBool(AnimatorHash.dribblingBool, false);
            playerAnimator.SetBool(AnimatorHash.shootingBool, true);
            
            //Get shot direction and turn player toward that before shot.
            transform.LookAt(shotDirection);
            shotDirection = new Vector3(shotTargetH.position.x, this.transform.position.y, shotTargetH.position.z);
            
            //Resets shotStart float.
            shotStart = 0;
            //Sets the game time to shotStart.
            shotStart = Mathf.FloorToInt(Time.time * 100);

        }
        //Release shot when button is released.
        else if (shooting == true && Input.GetButtonUp("Jump") && playerAnimator.GetBool(AnimatorHash.shootingBool) == true)
        {

             //Execute the shot success function to record and calculate based on release timing.
             ShotSuccessFunction();

            /*
             //Set Shot Type based on input timing.
             if (shotTiming > 25 && shotTiming < 65)
             {
                 ShotReleaseFunction();
             }else
             {
                 ShotFakeFunction();
             }
            */
            
            //Execute shot release.
            ShotReleaseFunction();

        
        }

	//end Update method.
    }


    //Used to re-enable all interactions after the shot animation has completed.
    private void ShotReleaseFunction()
    {
        //Reset variables and ball object physics
        gameBall.GetComponent<Rigidbody>().GetComponent<Collider>().enabled = true;
        gameBall.GetComponent<Rigidbody>().isKinematic = false;

        //re-set the ball object parent to null (ball has no parent)
        gameBall.parent = GameObject.Find("Items").transform;

        //Add force to push ball (using physics). Add shotSuccess modifier to target transform to change the target location based on timing (better timing, closer range to center of basket).
        gameBall.GetComponent<Rigidbody>().velocity = FindInitialVelocity(playerHand.position,(shotTargetH.transform.position+shotSuccessModifier));

        //add backspin to shot.
        gameBall.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.down * ballSpin * 50, ForceMode.Impulse);

        //Perform anim and state actions to release ball control.
        LosePossession();

        Debug.Log("Shot Release Function Complete");

	//end ShotReleaseFunction method.
    }
    

    //Used to complete shot function.
    private void ShotEndFunction()
    {
        //Reset player components after shot completed.
        playerAnimator.SetBool(AnimatorHash.shootingBool, false);
                
        Debug.Log("Shot End Function Complete");

        //end ShotEndFunction method.
    }


    //Handles the shot fake function where the shot input is less than shot action threshold.
    private void ShotFakeFunction()
    {
        //Transition animation back to idle.
        playerAnimator.SetBool(AnimatorHash.shootingBool, false);

        //end ShotFake method.
    }


    //Handles the shot success probabilities based on release timing.
    private void ShotSuccessFunction()
    {
		//Sets game time to shotRelease.
		shotRelease = Mathf.FloorToInt(Time.time*100);
		//Compare shotStart and shotRelease floats to get shot timing.
		shotTiming = (shotRelease - shotStart);
		Debug.Log("shotTiming " + shotTiming);
		
		//Calculate success value.
		shotSuccess = (100 - (Mathf.Abs(shotTiming - 45)*5));
        shotSuccess = 1 - (shotSuccess / 100);
		shotSuccessModifier = new Vector3(Random.Range(0,shotSuccess),Random.Range(0,shotSuccess),Random.Range(0,shotSuccess));
	
	//end ShotSuccess method.	
    }

    //Shot trajectory physics script.
    private Vector3 FindInitialVelocity(Vector3 startPosition, Vector3 finalPosition, float maxHeightOffset = 0.8f,
        float rangeOffset = 0.2f)
    {
        // get our return value ready. Default to (0f, 0f, 0f).
        var newVel = new Vector3();
        // Find the direction vector without the y-component.
        Vector3 direction = new Vector3(finalPosition.x, 0f, finalPosition.z) -
                            new Vector3(startPosition.x, 0f, startPosition.z);
        // Find the distance between the two points (without the y-component).
        float range = direction.magnitude;
        // Add a little bit to the range so that the ball is aiming at hitting the back of the rim.
        // Back of the rim shots have a better chance of going in.
        // This accounts for any rounding errors that might make a shot miss (when we don't want it to).
        range += rangeOffset;
        // Find unit direction of motion without the y component.
        Vector3 unitDirection = direction.normalized;
        // Find the max height
        // Start at a reasonable height above the hoop, so short range shots will have enough clearance to go in the basket.
        // without hitting the front of the rim on the way up or down.
        float maxYPos = shotTargetH.transform.position.y + maxHeightOffset;
        // check if the range is far enough away where the shot may have flattened out enough to hit the front of the rim.
        // if it has, switch the height to match a 45 degree launch angle.
        if (range/1.5f > maxYPos)
            maxYPos = range/1.5f;
        // find the initial velocity in y direction.
        newVel.y = Mathf.Sqrt(-2.0f*Physics.gravity.y*(maxYPos - startPosition.y));
        // find the total time by adding up the parts of the trajectory.
        // time to reach the max.
        float timeToMax = Mathf.Sqrt(-2.0f*(maxYPos - startPosition.y)/Physics.gravity.y);
        // time to return to y-target.
        float timeToTargetY = Mathf.Sqrt(-2.0f*(maxYPos - finalPosition.y)/Physics.gravity.y);
        // add them up to find the total flight time.
        float totalFlightTime = timeToMax + timeToTargetY;
        // find the magnitude of the initial velocity in the xz direction.
        float horizontalVelocityMagnitude = range/totalFlightTime;
        // use the unit direction to find the x and z components of initial velocity.
        newVel.x = horizontalVelocityMagnitude*unitDirection.x;
        newVel.z = horizontalVelocityMagnitude*unitDirection.z;
        return newVel;
    
	//end FindInitialVelocity method.
	}

    


//end class.
}