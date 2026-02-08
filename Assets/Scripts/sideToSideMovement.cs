using UnityEngine;

public class sideToSideMovement : MonoBehaviour
{

    public float speed = 0.5f;
    private bool goingRight;

    Vector3 maxRight;
    Vector3 maxLeft;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxRight = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
        maxLeft = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
        goingRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= maxRight.x)
        {
            goingRight = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(transform.position.x >= maxLeft.x)
        {
            goingRight = true;
            //Debug.Log("Going Right");
            GetComponent<SpriteRenderer>().flipX = false;
        }

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
