using UnityEngine;
using System.Collections;

public class mainAudio : MonoBehaviour
{
    //reference to audio source
    private AudioSource audio;
    
    //seperate timers for fade in/out
    public float FadeTimeIn;
    public float FadeTimeOut;

    private bool restartPrevention;

    private void Start()
    {
        restartPrevention = false;
        //define audio component
        audio = GetComponent<AudioSource>();
    }

    //coroutines are called in the "Audio" script and are triggered when
    //a player enters or exits the intro room
    IEnumerator FadeOut()
    {
        //stores current volume
        float volume = audio.volume;
        //time = 0 and counts up
        float time = 0f;

        //until time reaches fade out time...
        while (time < FadeTimeOut)
        {
            //increase time
            time += Time.deltaTime;
            //transition volume from current volume to 0
            audio.volume = Mathf.Lerp(volume, 0f, time / FadeTimeOut);
            yield return null;
        }
        //after fade out time...
        yield return new WaitForSeconds(FadeTimeOut);
        //...pause audio
        audio.Pause();
    }

    IEnumerator FadeIn()
    {
        //stores current volume
        float volume = audio.volume;
        //time = 0 and counts up
        float time = 0f;

        //start audio
        audio.Play();

        //reference below
        StartDancingPlants();

        //while time is less than fade in time...
        while (time < FadeTimeIn)
        {
            //increase time
            time += Time.deltaTime;
            //transition volume from current volume to 0.1
            audio.volume = Mathf.Lerp(volume, 0.2f, time / FadeTimeIn);
            yield return null;
        }
    }

    //finds each object with "squashStretch" script in the scene and starts
    //"SquishCoroutine"...makes plants dance
    public void StartDancingPlants()
    {
        if (restartPrevention == false)
        {
            //array of all squashStretch scripts in the scene
            squashStretch[] squashScript = FindObjectsOfType<squashStretch>();
            //start coroutine on each script instance
            foreach (squashStretch scriptInstance in squashScript)
            {
                scriptInstance.StartCoroutine("SquishCoroutine");
            }

            restartPrevention = true; 

        }
        
    }

    

    


}
