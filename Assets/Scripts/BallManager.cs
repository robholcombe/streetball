using UnityEngine;
using System.Collections;

public class BallManager : GameManager
{

    ///Public Static Variables
    public static Transform gameBall;
    
	// Use this for initialization
	void Awake()
    {
        //Get Manager scripts and object references.
        gameBall = GetComponent<Rigidbody>().transform;
     //end Awake method.  
	}
	

	// Update is called once per frame
	void Update()
    {
        //Cache transform.
        gameBall = GetComponent<Rigidbody>().transform;
         
    //end Update method.              	
	}


//end class.
}
