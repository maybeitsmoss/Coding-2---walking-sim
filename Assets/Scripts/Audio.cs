using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class Audio : MonoBehaviour
{

    //snapshots for audio mixer , used for intro audio
    public AudioMixerSnapshot unmutedSnap;
    public AudioMixerSnapshot mutedSnap;
    //fade time to transition between snapshots
    public float fadeTime;

    //references to audio and mixer
    private AudioSource audio;
    private AudioMixer mixer;

    //weight and snapshot references used in fade timer
    private float[] weights;
    private AudioMixerSnapshot[] snapshots;

    //reference to the main audio script , used for main background audio
    public mainAudio mainAudioScript;

    //reference to the player controller to control speed
    public PlayerController playerController;
    //player speed in intro room
    public float slowSpeed;

    //on start define audio and mixer components
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        mixer = audio.outputAudioMixerGroup.audioMixer;

        snapshots = new AudioMixerSnapshot[]
        {
            unmutedSnap, //index 0
            mutedSnap    //index 1
        };
        //make an array of size [2] (two values)
        weights = new float[2];
    }


    private void OnTriggerEnter(Collider other)
    {
        //when the player enters....
        if(other.tag == "Player" )
        {
            //start audio and begin fade in transition for intro audio
            audio.Play();
            weights[0] = 1;
            weights[1] = 0;
            mixer.TransitionToSnapshots(snapshots, weights, fadeTime);

            //slow player speed in intro room
            playerController.moveSpeed = slowSpeed;

            //fade out of main background music
            mainAudioScript.StartCoroutine("FadeOut");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        //when the player leaves.....
        if(other.tag == "Player")
        {
            //fade in main background music
            mainAudioScript.StartCoroutine("FadeIn");

            //fade out of intro music
            weights[0] = 0;
            weights[1] = 1;
            mixer.TransitionToSnapshots(snapshots, weights, fadeTime);

            //speed player up
            playerController.moveSpeed =4.5f;

            //stop audio after fade out
            StartCoroutine(StopAudio());

        }
    }

    IEnumerator StopAudio()
    {
        //stop audio when fade is done
        yield return new WaitForSeconds(fadeTime);

        audio.Stop();
    }

}
