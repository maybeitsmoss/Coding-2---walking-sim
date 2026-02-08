using UnityEngine;

public class waterToggle : MonoBehaviour
{
    public GameObject water;
    private Renderer waterRenderer;
    //private bool toggleOn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waterRenderer = water.GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && waterRenderer.enabled == true)
        {
            //toggleOn = false;
            waterRenderer.enabled = false;
        }
        else if(other.gameObject.CompareTag("Player") && waterRenderer.enabled == false)
        {
            //toggleOn = true;
            waterRenderer.enabled = true;
        }
    }
}
