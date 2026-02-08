using UnityEngine;

public class bigTank : MonoBehaviour
{

    public float speed = 0.5f;
    private bool goingRight;

    Vector3 maxRight;
    Vector3 maxLeft;
    

    void Start()
    {
        //assign variables for the range of movement
        maxRight = new Vector3(transform.position.x, transform.position.y, transform.position.z + 8f);
        maxLeft = new Vector3(transform.position.x, transform.position.y, transform.position.z - 8f);
        //send the fish in a direction to start
        goingRight = false;   
    }

    
    void Update()
    {
        //when fish hits either end of its range..........
        if (transform.position.z >= maxRight.z)
        {
            goingRight = false;
            //flip sprite
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (transform.position.z <= maxLeft.z)
        {
            goingRight = true;
            //flip sprite
            GetComponent<SpriteRenderer>().flipX = false;
        }

         //.........assign new direction to move in
        if(goingRight == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, maxRight, speed * Time.deltaTime);
        }
        else if(goingRight == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, maxLeft, speed * Time.deltaTime);
        }
    }
}
