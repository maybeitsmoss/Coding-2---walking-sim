//using System.Numerics;
//using System.Runtime.CompilerServices;
//using System.Threading.Tasks.Dataflow;
//using Microsoft.CSharp.RuntimeBinder;
using UnityEditor.Build;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6;
    public float gravity = 0.1f;
    public float groundCheckRadius = 0.15f;
    public float jumpForce = 15f;
    public LayerMask groundLayer;

    private bool isGrounded;
    private Vector3 velocity;
    private Transform feet;

    private static bool movingForward;

    private CharacterController controller;



    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        feet = transform.Find("feet");
    }

    private void Start()
    {
        if(movingForward == true)
        {
            transform.position = new Vector3(0, 1, -23);
        }
        else
        {
            transform.position = new Vector3(0, 1, 6);
        }
    }

    private void Update()
    {
        CheckisGrounded();
        Move();
        ApplyGravity();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move);
    }

    private void CheckisGrounded()
    {
        isGrounded = Physics.CheckSphere(feet.position, groundCheckRadius, groundLayer);
    }

    private void ApplyGravity()
    {
        velocity += Vector3.down * gravity * Time.deltaTime;
        if (isGrounded)
        {
            velocity = Vector3.zero;
        }

        controller.Move(velocity);
    }

    /*public void SetMovingForward(bool moveForward)
    {
        movingForward = moveForward;
    }*/


    /*private void Jump()
    {
        rb = GetComponent<RigidBody>();
        Vector3 velocity = rb.velocity;


        velocity = Vector3(velocity.X, velocity.Y, jumpForce);
    }*/


}
