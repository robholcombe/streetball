using UnityEngine;
using System.Collections;

public class AnimatorHash : MonoBehaviour 
{
    //Public Variables
	public static int speedFloat;
    public static int dribblingBool;
    public static int shootingBool;

    //On awake, set animator hashes.
	void Awake()
	{
        speedFloat = Animator.StringToHash("speed");
        dribblingBool = Animator.StringToHash("dribbling");
        shootingBool = Animator.StringToHash("shooting");


    //end awake method.
	}

//end class.
}
