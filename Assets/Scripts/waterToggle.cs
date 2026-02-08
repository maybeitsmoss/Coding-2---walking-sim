using UnityEngine;

public class waterToggle : MonoBehaviour
{
    public GameObject water;
    private Renderer waterRenderer;

    //public GameObject water1;
    //private Renderer water1Renderer;
    

    //assigns renderer component at start
    void Start()
    {
        waterRenderer = water.GetComponent<Renderer>();
        
    }

    //when player enters trigger box...
    void OnTriggerEnter(Collider other)
    {
        //if the water is visible, make it invisible
        if(other.gameObject.CompareTag("Player") && waterRenderer.enabled == true)
        {
            
            waterRenderer.enabled = false;
            
        }
        //if the water is invisible, make it visible
        else if(other.gameObject.CompareTag("Player") && waterRenderer.enabled == false)
        {
            
            waterRenderer.enabled = true;
            
        }
    }
}
