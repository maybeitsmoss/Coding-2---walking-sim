using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextRoom : MonoBehaviour
{
    private int currentSceneIndex;
    public int totalScenes = 4;
    private string thisTag;

    private static int lastScene;

    private static Stack sceneHistory = new Stack();

    //public PlayerController playerController;

    private void Start()
    {
        thisTag = gameObject.tag;
        //sceneHistory.Push(SceneManager.GetActiveScene().buildIndex);
        
    }
    


    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player") && thisTag == "nextScene")
        {
            sceneHistory.Push(SceneManager.GetActiveScene().buildIndex);
            GetRandomScene();

        }
        else if (other.gameObject.CompareTag("Player") && thisTag == "lastScene")
        {
            if(sceneHistory.Count == 0)
            {
                return;
            }
            else
            {
                //playerController.SetMovingForward(false);
                SceneManager.LoadScene((int)sceneHistory.Pop());
            }
            
        }
    }

    private void GetRandomScene()
    {
        
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int randomSceneIndex = Random.Range(0, totalScenes);

        while (randomSceneIndex == currentSceneIndex)
        {
            randomSceneIndex = Random.Range(0, totalScenes);
        }

        //playerController.SetMovingForward(true);        
        SceneManager.LoadScene(randomSceneIndex);
    }
}
