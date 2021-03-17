using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AgentController : MonoBehaviour
{
    scr_IInput input;
    scr_AgentMovement movement;

    private void OnEnable()
    {
        input = GetComponent<scr_IInput>();
        movement = GetComponent<scr_AgentMovement>();
        input.OnMovementDirectionInput += movement.HandleMovementDirection;
        input.OnMovementInput += movement.HandleMovement;
    }

    private void OnDisable()
    {
        input.OnMovementDirectionInput -= movement.HandleMovementDirection;
        input.OnMovementInput -= movement.HandleMovement;
    }
}
