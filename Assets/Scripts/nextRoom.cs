using UnityEngine;
using UnityEngine.SceneManagement;

public class nextRoom : MonoBehaviour
{
    private int currentSceneIndex;
    public int totalScenes = 4;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetRandomScene();

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

        SceneManager.LoadScene(randomSceneIndex);
    }
}
