using UnityEngine;

public class waterToggle : MonoBehaviour
{
    //reference to game object and renderer
    public GameObject water;
    private Renderer waterRenderer;

    private randomMovement randomMovementScript;

    //assigns renderer component at start
    void Start()
    {
        waterRenderer = water.GetComponent<Renderer>();
        
    }

    //when player enters trigger box...
    void OnTriggerEnter(Collider other)
    {
        //if the water is visible and player entered "off" box...
        if(other.gameObject.CompareTag("Player") && waterRenderer.enabled == true && gameObject.tag == "off")
        {
            //...turn water off
            waterRenderer.enabled = false;
            makeFreeRotation();
            
        }
        //if the water is invisible and player entered "on" box...
        else if(other.gameObject.CompareTag("Player") && waterRenderer.enabled == false && gameObject.tag == "on")
        {
            //...turn water on
            waterRenderer.enabled = true;
            stopFreeRotation();
            
        }
    }

    public void makeFreeRotation()
    {
        randomMovement[] randomScript = FindObjectsOfType<randomMovement>();
        foreach (randomMovement scriptInstance in randomScript)
        {
            scriptInstance.freeRotation = true;
        }
    }

    public void stopFreeRotation()
    {
        randomMovement[] randomScript = FindObjectsOfType<randomMovement>();
        foreach (randomMovement scriptInstance in randomScript)
        {
            scriptInstance.freeRotation = false;
        }
    }

    //this is to hide the water at certain points in the level when it
    //clips through lower areas of the level
}
