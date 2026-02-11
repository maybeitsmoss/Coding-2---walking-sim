using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class dimAudio : MonoBehaviour
{
    public AudioMixerSnapshot unmutedSnap;
    public AudioMixerSnapshot dimmedSnap;
    public float fadeTime;

    public GameObject mainAudioOBJ;
    private AudioSource audioClip;
    private AudioMixer mixer;

    private float[] weights;
    private AudioMixerSnapshot[] snapshots;

    public void Start()
    {
        audioClip = mainAudioOBJ.GetComponent<AudioSource>();
        mixer = audioClip.outputAudioMixerGroup.audioMixer;

        snapshots = new AudioMixerSnapshot[]
        {
            unmutedSnap,
            dimmedSnap
        };

        weights = new float[2];
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            weights[0] = 0;
            weights[1] = 1;

            mixer.TransitionToSnapshots(snapshots, weights, fadeTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            weights[0] = 1;
            weights[1] = 0;

            mixer.TransitionToSnapshots(snapshots, weights, fadeTime);
        }
    }
}
