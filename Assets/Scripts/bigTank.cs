using UnityEngine;

public class bigTank : MonoBehaviour
{

    public float speed = 0.5f;
    private bool goingRight;

    Vector3 maxRight;
    Vector3 maxLeft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxRight = new Vector3(transform.position.x, transform.position.y, transform.position.z + 8f);
        maxLeft = new Vector3(transform.position.x, transform.position.y, transform.position.z - 8f);
        goingRight = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= maxRight.z)
        {
            goingRight = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (transform.position.z <= maxLeft.z)
        {
            goingRight = true;
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
