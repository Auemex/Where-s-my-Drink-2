using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface scr_IInput
{
    Action<Vector3> OnMovementDirectionInput { get; set; }
    Action<Vector2> OnMovementInput { get; set; }
}

