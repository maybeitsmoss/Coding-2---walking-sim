using UnityEngine;

public class startingBlockade : MonoBehaviour
{

    public GameObject player;
    private Transform playerTransform;
    private Transform transform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        while (transform.position.z <= -47f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, playerTransform.position.z - 1f);
        }
    }
}
