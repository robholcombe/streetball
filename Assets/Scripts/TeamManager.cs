using UnityEngine;

public class TeamManager : MonoBehaviour
{
    //Public variables
    public GameObject HomePlayerSlot01;
    public GameObject HomePlayerSlot02;
    public GameObject HomePlayerSlot03;
    public GameObject AwayPlayerSlot01;
    public GameObject AwayPlayerSlot02;
    public GameObject AwayPlayerSlot03;

    //Private Team-based Variables
    public PlayerSelection playerSelection;
    

    //On startup
    void Start()
    {
        //Get PlayerList script
        playerSelection = FindObjectOfType(typeof(PlayerSelection)) as PlayerSelection;

        //Instantiate teamList object
        //List<GameObject> teamList = new List<GameObject>();

        //Get all active players in game to teamList (uses Player tag).
        /*
         * teamList.Add(playerSelection.HomePlayerSlot01, "H");
        teamList.Add(playerSelection.HomePlayerSlot02, "H");
        teamList.Add(playerSelection.HomePlayerSlot03, "H");
        teamList.Add(playerSelection.AwayPlayerSlot01, "A");
        teamList.Add(playerSelection.AwayPlayerSlot02, "A");
        teamList.Add(playerSelection.AwayPlayerSlot03, "A");
        */
        //Assign all players to their team.
        //GameObject.Find(HomePlayerSlot01);





    }


    void Update()
    {



    }






//end script
}