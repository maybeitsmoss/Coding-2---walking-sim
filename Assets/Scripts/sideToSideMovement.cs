using UnityEngine;
using System.Collections;

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

        StartCoroutine("WhaleMovement");
    }

    
    void Update()
    {
        //when fish hits either end of its range..........
        if(transform.position.x <= maxRight.x && gameObject.tag != "whale")
        {
            goingRight = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(transform.position.x >= maxLeft.x && gameObject.tag != "whale")
        {
            goingRight = true;
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //.........assign new direction to move in
        if(goingRight == true && gameObject.tag != "whale")
        {
            transform.position = Vector3.MoveTowards(transform.position, maxRight, speed * Time.deltaTime);
        }
        else if(goingRight == false && gameObject.tag != "whale")
        {
            transform.position = Vector3.MoveTowards(transform.position, maxLeft, speed * Time.deltaTime);
        }
    }

    IEnumerator WhaleMovement()
    {
        //whale moves side to side but pauses at each end for 2 seconds
        if(gameObject.tag == "whale")
        {
            float time = 0f;
            while(transform.position.x >= maxRight.x)
            {
                time += Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, maxRight, speed * Time.deltaTime);
                //yield return null;
            }
            Debug.Log("Reached right");

        }

        yield return new WaitForSeconds(2f);

        if(gameObject.tag == "whale")
        {
            float time = 0f;
            while(transform.position.x <= maxLeft.x)
            {
                time += Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, maxLeft, speed * Time.deltaTime);
                //yield return null;
            }
            Debug.Log("Reached left");
        }

        yield return new WaitForSeconds(1f);
    }
}
