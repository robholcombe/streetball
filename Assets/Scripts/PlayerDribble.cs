using UnityEngine;
using System.Collections;

public class PlayerDribble : PlayerManager
{
    /*
	private float lerpTime = 1f;
    private float currentLerpTime;
    private float percTime;
	
    //public for testing. This is the dribble (up/down) bools that control the lerp.
    public bool dribbleDownBool;
    public bool dribbleUpBool;

    //GameObject references to the downward and upward dribble positions. These are used to lerp the ball between during the dribble motion.
    public Vector3 dribbleDown; //= Vector3(0.2458516,0.12,0.6657132);
    public Vector3 dribbleUp; //= Vector3(0.34948,1.501298,0.5157773);


    void Awake()
    {
		//Get object reference.
        dribbleDown = transform.Find("DribbleDown").transform.position;
        dribbleUp = transform.Find("DribbleUp").transform.position;

    //end awake method.
    }

    void Start()
    {

    }


    void FixedUpdate()
    {

        //Check if dribbling in enabled then perform function.
        if (dribbling == true)
        {
            //Set dribbling bool to tell playMaker to start dribbling ball movement.
            DribbleFunction();
            //playerAnim.SetBool("dribbling", true);
        }
         
     //end update method.   
     }
    

	void DribbleFunction()
    {
		//Reset lerpTime variable before starting calculation.
		currentLerpTime = 0f;
		
		//Increment Lerp timer once per frame
        currentLerpTime += Time.deltaTime;
		
		//Update currentLerpTime to default if greater.
		if (currentLerpTime > lerpTime)
		{
            currentLerpTime = lerpTime;
        }
	
		//Dribble down lerp.
        if (dribbleDownBool == true && dribbleUpBool == false)
        {
			percTime = currentLerpTime / lerpTime;
            gameBall.transform.position = Vector3.Lerp(dribbleUp, dribbleDown, percTime);
        }
		//Dribble up lerp.
        else if (dribbleUpBool == true && dribbleDownBool == false)
        {
			percTime = currentLerpTime / lerpTime;
			percTime = Mathf.Sin(Time.deltaTime * Mathf.PI * 0.5f);
            gameBall.transform.position = Vector3.Lerp(dribbleDown, dribbleUp, percTime);
        }

    //end Dribble method.
    }

    //Animation event trigger for the downward motion.
    void DribbleDownEvent(int DribbleDownEventInt)
    {
        dribbleDownBool = true;
        dribbleUpBool = false;
    }

    //Animation event trigger for the upward motion.
    void DribbleUpEvent(int DribbleUpEventInt)
    {
        dribbleDownBool = false;
        dribbleUpBool = true;
    }
 
    */
 //end script
}