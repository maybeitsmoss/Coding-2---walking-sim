using UnityEngine;

public class tankMovement : MonoBehaviour
{
    public float speed = 0.5f;
    //Vector3 position = transform.position;
    private bool goingUp;

    Vector3 maxUp;
    Vector3 maxDown;



    void Start()
    {   
        //assign variables for the range of movement
        maxUp = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        maxDown = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        //send the fish in a direction to start
        goingUp = true;
        
    }

    
    void Update()
    {
        //when fish hits either end of its range..........
        if(transform.position.y >= maxUp.y)
        {
            goingUp = false;
        }
        else if(transform.position.y <= maxDown.y)
        {
            goingUp = true;
        }
        //.........assign new direction to move in
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
