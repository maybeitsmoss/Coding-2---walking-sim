using UnityEngine;

public class waterToggle : MonoBehaviour
{
    public GameObject water;
    private Renderer waterRenderer;

    public GameObject water1;
    private Renderer water1Renderer;
    //private bool toggleOn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waterRenderer = water.GetComponent<Renderer>();
        //water1Renderer = water1.GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && waterRenderer.enabled == true)
        {
            //toggleOn = false;
            waterRenderer.enabled = false;
            //water1Renderer.enabled = false;
        }
        else if(other.gameObject.CompareTag("Player") && waterRenderer.enabled == false)
        {
            //toggleOn = true;
            waterRenderer.enabled = true;
            //water1Renderer.enabled = true;
        }
    }
}
