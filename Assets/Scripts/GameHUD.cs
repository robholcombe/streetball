using UnityEngine;

public class GameHUD : GameManager
{
    //On update, refresh HUD elements
    void Update()
    {
        //Display time in HUD while greater than zero.
        if (gameSeconds > 0)
        {
            //REQUIRES DEVELOPMENT.
            //GetComponent(TextMesh).text = String.Format("{0:00}:{1:00}:{2:00}", gameMinutes, gameSeconds, gameFraction);
        }
    
    }




}