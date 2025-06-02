using UnityEngine;
using System.Collections;

public class PlayerPossession : PlayerManager
{
    //Private Variables.
    private float getBallDist = 1.5f; //Move to 1 later when animation can handle this. 1 is close enough to grab without being to unrealistic.
    private float distTest = 0f; //Zero (0) is default starting value.
    

    //Update on every frame.
    void Update()
    {
        //Only poll for ball status if player doesn't have ball and is not shooting.
        if (playerAnimator.GetBool(AnimatorHash.dribblingBool) == false && playerAnimator.GetBool(AnimatorHash.shootingBool) == false)
        {
            //Test distance between player and ball.
            distTest = Vector3.Distance(playerBody.position, gameBall.position);

            //If player is close enough to ball, attempt to gain possession
            if (distTest < getBallDist)
            {
                //Perform the GetBallEvent function to take possession of ball game object.
                GainPossession();
            }
        
        }

    //end Update method.
    }


    //The function to control when and how the player picks up a loose ball
    public void GainPossession()
    {
        Debug.Log("Gain Possession Started");
        //If the ball is in control of a player, set variables and ball object physics
        //Set main variables.
        BallManager.gameBall.GetComponent<Rigidbody>().GetComponent<Collider>().enabled = false;
        BallManager.gameBall.GetComponent<Rigidbody>().isKinematic = true;

        //Set ball parent and position to player hand.
        BallManager.gameBall.parent = playerHand;
        BallManager.gameBall.transform.position = new Vector3(playerHand.transform.position.x, playerHand.transform.position.y, playerHand.transform.position.z);

        //Set ball handler id so it knows which player is in control
        //**DEBUG** This is a hard coded int to register the player. NEed to assign this somewhere
        GameManager.AssignBallHandler(playerID);
        
        //Set animator bool so animation plays.        
        playerAnimator.SetBool(AnimatorHash.dribblingBool, true);

        Debug.Log("Gain Possession Complete");

        //end PlayerGetBall method.
    }
   
//end class.
}
