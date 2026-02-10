//using System.Numerics;
//using System.Runtime.CompilerServices;
//using System.Threading.Tasks.Dataflow;
//using Microsoft.CSharp.RuntimeBinder;
using UnityEditor.Build;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player move speed (slow for good fish observation!)
    public float moveSpeed = 3;
    //gravity force
    public float gravity = 0.1f;
    //ground check distance
    public float groundCheckRadius = 0.15f;
    //layer mask for ground check
    public LayerMask groundLayer;

    //stores if grounded
    private bool isGrounded;
    //velocity reference
    private Vector3 velocity;
    //feet transform reference
    private Transform feet;
    //reference to character controller component
    private CharacterController controller;



    private void Awake()
    {
        //assign controller and feet components
        controller = GetComponent<CharacterController>();
        feet = transform.Find("feet");
    }

    private void Update()
    {
        CheckisGrounded();
        Move();
        ApplyGravity();
    }

    private void Move()
    {
        //get input axis and apply based on move speed
        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //move player based on input + orientation
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move);
    }

    private void CheckisGrounded()
    {
        //check for ground based on feet position, check radius + layer
        isGrounded = Physics.CheckSphere(feet.position, groundCheckRadius, groundLayer);
    }

    private void ApplyGravity()
    {
        //move player downward based on gracity force
        velocity.y += gravity * Time.deltaTime;
        //move the player
        controller.Move(velocity);
    }
}
