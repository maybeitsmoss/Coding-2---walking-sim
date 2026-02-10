using UnityEngine;
using System.Collections;

public class people : MonoBehaviour
{
    public Vector3 destination1;
    public Vector3 destination2;
    public Vector3 destination3;

    public float speed;

    private int destinationTracker;

    public Transform cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main.transform;
        StartCoroutine("WalkAnim");
        destinationTracker = 1 ;
    }

    // Update is called once per frame
    void Update()
    {
        Move(destinationTracker);
    }

    void LateUpdate()
    {
        transform.LookAt(cam);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    private void GetPos()
    {
        if (destinationTracker == 1)
        {
            destinationTracker = 2;
        }
        else if (destinationTracker == 2)
        {
            destinationTracker = 1;
        }
    }
    private void Move(int destination)
    {
        if(destination == 1 && transform.position != destination1)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, destination1, speed * Time.deltaTime);
            //destinationTracker = 2;
        }
        else if(destination == 1 && transform.position == destination1)
        {
            GetPos();
        }
        else if(destination == 2 && transform.position != destination2)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination2, speed * Time.deltaTime);
            
        }
        else if(destination == 2 && transform.position == destination2)
        {
            GetPos();
        }
        /*else if(destination == 3)
        {
            while (transform.position != destination3)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination3, speed * Time.deltaTime);
            }
            destinationTracker = 1;
        }*/

        
    }

    IEnumerator WalkAnim()
        {
            yield return new WaitForSeconds(0.365f);
            //Debug.Log("WalkAnim started");
            GetComponent<SpriteRenderer>().flipX = true;

            yield return new WaitForSeconds(0.365f);
            //Debug.Log("WalkAnim part 2");
            GetComponent<SpriteRenderer>().flipX = false;
            StartCoroutine("WalkAnim");
        }
}
