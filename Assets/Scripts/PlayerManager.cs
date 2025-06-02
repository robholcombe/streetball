using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{

    //Public variables.
    [Header("Class References")]
	public Animator playerAnimator;

    [Header("GameObject References")]
	public Transform playerHand;
    public Transform playerBody;
	public Transform gameBall;
    public Transform shotTargetH;
    public bool shooting;
    public AnimatorHash animatorHash; //Reference to the animatorHashID script.    

    //DEBUG* Used to record ball handler, will be set by GameManager when assigning teams in future.
    public static int playerID = 100;
        
    //Private variables.
    public int playerTeam = 0; //0 = home, 1 = away.
    

    //On awake set animators and hashes.
    void Awake()
    {
        //Set references to player mesh.
        playerBody = GetComponent<Rigidbody>().transform;
        playerHand = transform.Find("Player_01/v1/hips/spine/chest/clavicle_R/upper_arm_R/forearm_R/hand_R").transform;

        //Set script references
        playerAnimator = GetComponent<Animator>(); //The GetComponent command returns an array, so the [1] means take the first Animator component from this array.
        animatorHash = GetComponent<AnimatorHash>(); 

        //Set weight of animator controller.
        if (playerAnimator.layerCount == 2)
        {
            playerAnimator.SetLayerWeight(1, 1);
        }

        //Get assigned team and store for player. 0 = home, 1 = away.
        playerTeam = 0;

	//end awake method.	
    }

    void Start()
    {
        //Set static GameObject references.
        gameBall = BallManager.gameBall;
        shotTargetH = GameManager.shotTargetH;
    }

    //Update is called once per frame.
    void Update()
    {
        //Cache player rigidbody transform (location) every frame.
        playerBody = GetComponent<Rigidbody>().transform;

            
    //end Update method.
    }


    //Function to reset ball variables once player has lost possession of ball (ball is loose with no parent).
    public void LosePossession()
    {
        Debug.Log("Lose Possession Started");
        //Reset variables and ball object physics
        BallManager.gameBall.GetComponent<Rigidbody>().GetComponent<Collider>().enabled = true;
        BallManager.gameBall.GetComponent<Rigidbody>().isKinematic = false;

        //re-set the ball object parent to null (ball has no parent)
        BallManager.gameBall.parent = GameObject.Find("Items").transform;

        GameManager.AssignBallHandler(0);

        playerAnimator.SetBool(AnimatorHash.shootingBool, false);
        Debug.Log("Lose Possession Complete");

        //end PlayerLoseBall method.
    }


//end class.
}
