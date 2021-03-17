using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AgentMovement : MonoBehaviour
{
    [SerializeField]
    GameObject Player;    
    CharacterController controller;

    public float rotationSpeed, movementSpeed, gravity = 1;
    Vector3 movementVector = Vector3.zero;
    private float desiredRotationAngle = 0;

    private float inputVerticalDirection;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void HandleMovement(Vector2 input)
    {
        if (controller.isGrounded)
        {
            if(input.y != 0)
            {
                if(input.y > 0)
                {
                    inputVerticalDirection = Mathf.CeilToInt(input.y);
                }
                else
                {
                    inputVerticalDirection = Mathf.FloorToInt(input.y);
                }
                movementVector = input.y * transform.forward * movementSpeed;
            }
            else
            {
                movementVector = Vector3.zero;
            }
        }
    }

    public void HandleMovementDirection(Vector3 direction)
    {
        desiredRotationAngle = Vector3.Angle(transform.forward, direction);
        var crossProduct = Vector3.Cross(transform.forward, direction).y;
        if (crossProduct < 0)
        {
            desiredRotationAngle *= -1;
        }
    }

    private void RotateAgent()
    {
        if (desiredRotationAngle > 10 || desiredRotationAngle < -10)
        {
            transform.Rotate(Vector3.up * desiredRotationAngle * rotationSpeed * Time.deltaTime);
        }
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
            if (movementVector.magnitude > 0)
            {
                RotateAgent();
            }

            if (Input.GetButtonDown("Jump"))
            {
                gravity = -1;

            }
        }

        if (Player.transform.position.y >= 2)
            gravity = 1;

        Debug.Log("is grounded " + controller.isGrounded);

        movementVector.y -= gravity;
        controller.Move(movementVector * Time.deltaTime);
    }
}
