using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    
    //Public Static Varaibles
    [Header("Game Management")]
    public static int gameScore;
    public static int teamPosession;
    public static Transform shotTargetA;
    public static Transform shotTargetH;
    public static int ballHandler;
    
    //Public static game clock variables
    [Header("Game Clock")]
    public static float gameMinutes;
    public static float gameSeconds;
    public static float gameFraction;
    
    //Private Variables
    private float gameTime;

    
    //On startup, initialize variables
    void Awake()
    {
        
        //Assign shot targets
        shotTargetH = GameObject.FindWithTag("RimH").transform;
        //shotTargetA = GameObject.FindWithTag("RimA").transform; //DOESNT EXIST YET.

        //Set 300 seconds to starting game time (5 minutes)
        gameTime = 300;

    }


    //Update every frame
    void Update()
    {
        //Subtract seconds from gameTime via deltaTime
        gameTime -= Time.deltaTime;

        //Separate gameTime into min/sec/frac attributes for HUD display.
        gameMinutes = gameTime / 60;
        gameSeconds = gameTime % 60;
        gameFraction = (gameTime * 100) % 100;

    }


    //Handles the functionality of assigning and removing ball handler attribute.
    public static void AssignBallHandler(int playerID)
    {
        //Take input integer "playerID" and pass to ballHandler attribute in GameManager base class if current ballHandler is zero (no handler).        
        if (ballHandler == 0)
            ballHandler = playerID;

        //end AssignBallHandler method.
    }

//end script
}
