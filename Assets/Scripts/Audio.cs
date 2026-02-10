using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class Audio : MonoBehaviour
{

    //private AudioSource audio;
    public AudioMixerSnapshot unmutedSnap;
    public AudioMixerSnapshot mutedSnap;
    public float fadeTime;

    private AudioSource audio;
    private AudioMixer mixer;
    private float[] weights;
    private AudioMixerSnapshot[] snapshots;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && gameObject.tag != "mainAudio")
        {
            audio.Play();
            weights[0] = 1;
            weights[1] = 0;
            mixer.TransitionToSnapshots(snapshots, weights, fadeTime);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" && gameObject.tag != "mainAudio")
        {
            weights[0] = 0;
            weights[1] = 1;
            mixer.TransitionToSnapshots(snapshots, weights, fadeTime);
            StartCoroutine(StopAudio());
        }
    }

    IEnumerator StopAudio()
    {
        yield return new WaitForSeconds(fadeTime);

        audio.Stop();
    }
}
