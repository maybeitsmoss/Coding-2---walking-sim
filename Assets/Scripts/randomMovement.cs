using UnityEngine;

public class randomMovement : MonoBehaviour
{
    public float speed = 3f;
    public float rotateSpeed = 10f;
    //private Vector3 previousPosition;
    Vector3 randomPos;

//on start, pick a random direction
    void Start()
    {
        //previousPosition = transform.position;
        PickRandomPos();
    }

//random position selector
    void PickRandomPos()
    {
        //get a random point within confines
        float randomX = Random.Range(-24f, 2f);
        float randomZ = Random.Range(65f, 94f);

        //assign random position to randomPos variable
        randomPos = new Vector3(randomX, transform.position.y, randomZ);

        //Debug.Log("Random Position: " + randomPos);
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

        Vector3 moveDirection = randomPos - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

        transform.rotation = Quaternion.Euler(
            transform.eulerAngles.x,
            targetRotation.eulerAngles.y - 180,
            transform.eulerAngles.z
        );

        //Vector3 deltaPosition = transform.position - previousPosition;
        //Quaternion targetRotation = Quaternion.LookRotation(deltaPosition.normalized);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        //previousPosition = transform.position;
        //Vector3 direction = randomPos - transform.position;
        //Quaternion toRotation = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
    }
}
