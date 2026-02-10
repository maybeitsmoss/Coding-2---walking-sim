using UnityEngine;

public class randomMovement : MonoBehaviour
{
    //speed of fish
    public float speed = 3f;
    //stores random position
    private Vector3 randomPos;

    public bool freeRotation = false;
    private Transform cam;

    //on start, pick a random position
    void Start()
    {
        cam = Camera.main.transform;
        PickRandomPos();
    }

    //random position selector
    void PickRandomPos()
    {
        //get a random point within confines
        float randomX = Random.Range(-24f, 2f);
        float randomZ = Random.Range(65f, 85f);

        //assign random position to randomPos variable
        randomPos = new Vector3(randomX, transform.position.y, randomZ);
    }

    void Update()
    {
        //move towards new position with variable speed
        transform.position = Vector3.MoveTowards(transform.position, randomPos, speed * Time.deltaTime);

        //when the object reaches its destination...
        if (transform.position == randomPos)
        {
            //pick a new random position
            PickRandomPos();
        }

        if(freeRotation == false)
        {
            GetComponent<SpriteRenderer>().flipY = false;
            //get the durection of movement....
            Vector3 moveDirection = randomPos - transform.position;

            //....to get an angle of rotation.....
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            //....and rotate towards it
            transform.rotation = Quaternion.Euler(
                -90,
                //keeps Y axis correct (-180)
                targetRotation.eulerAngles.y - 180,
                0
            );
        }
        else if (freeRotation == true)
        {
            transform.LookAt(cam);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, -90);
            if(randomPos.x <= transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipY = true;
            }
            else if (randomPos.x >= transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipY = false;
            }
        }
        
    }

    
}
