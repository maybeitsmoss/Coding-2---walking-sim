using UnityEngine;

public class tankMovement : MonoBehaviour
{
    public float speed = 0.5f;
    //Vector3 position = transform.position;
    private bool goingUp;

    Vector3 maxUp;
    Vector3 maxDown;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxUp = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        maxDown = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        goingUp = true;
        //UpAndDown();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= maxUp.y)
        {
            goingUp = false;
        }
        else if(transform.position.y <= maxDown.y)
        {
            goingUp = true;
        }

        if(goingUp == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, maxUp, speed * Time.deltaTime);
        }
        else if(goingUp == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, maxDown, speed * Time.deltaTime);
        }

    }
}
