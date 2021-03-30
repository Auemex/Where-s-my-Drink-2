using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Destination : MonoBehaviour
{
    float rotation = 0f;
    float length = 5f;

    float sensitivity;


    void Update()
    {    
        if (Input.GetKeyDown("up"))
            {
                length = length + 1;
            }
            if (Input.GetKeyDown("down"))
            {
                length = length - 1;
            }
            if (Input.GetKey("left"))
            {
                rotation = rotation - 1;
            }
            if (Input.GetKey("right"))
            {
                rotation = rotation + 1;
            }
        
        RPcap();
        
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, rotation, transform.localRotation.z);
        transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y,length);
    }
    void RPcap()
    {
        if (length >= 5)
        {
            length = 5;
        }

        if (length <= 2)
        {
            length = 2;
        }

        if (rotation >= 360)
        {
            rotation = 0;
        }
        if (rotation <= -1)
        {
            rotation = 359;
        }
    }
}
