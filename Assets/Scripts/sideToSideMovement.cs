using UnityEngine;

public class sideToSideMovement : MonoBehaviour
{
    //speed of fish
    public float speed = 0.5f;
    //stores direction
    private bool goingRight;

    //max/min movement confines
    Vector3 maxRight;
    Vector3 maxLeft;


    
    void Start()
    {
        //assign variables for the range of movement
        maxRight = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
        maxLeft = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
        //send the fish in a direction to start
        goingRight = false;
    }

    
    void Update()
    {
        //when fish hits either end of its range..........
        if(transform.position.x <= maxRight.x)
        {
            goingRight = false;
            if(gameObject.tag != "whale")
            {
                //flip sprite UNLESS it is the whale
                GetComponent<SpriteRenderer>().flipX = true;
            }
            
        }
        else if(transform.position.x >= maxLeft.x)
        {
            goingRight = true;
            if(gameObject.tag != "whale")
            {
                //flip sprite UNLESS it is the whale
                GetComponent<SpriteRenderer>().flipX = false;
            }
            
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
