using UnityEngine;
using System.Collections;

public class GameSounds : MonoBehaviour
{

    //Public Variables
    public AudioClip ballHitCourt;
    public AudioClip ballHitNet;
    public AudioClip ballHitRim;

    //Handles Court collision sounds
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Court")
        {
            GetComponent<AudioSource>().clip = ballHitCourt;
            GetComponent<AudioSource>().Play();
        }


    }

    //Handles Net and Rim trigger collision sounds
    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.GetComponent<Collider>().tag == "Net")
        {
            GetComponent<AudioSource>().clip = ballHitNet;
            GetComponent<AudioSource>().Play();
        }

        if (trigger.GetComponent<Collider>().tag == "Rim")
        {
            GetComponent<AudioSource>().clip = ballHitRim;
            GetComponent<AudioSource>().Play();
        }

    }		


}
