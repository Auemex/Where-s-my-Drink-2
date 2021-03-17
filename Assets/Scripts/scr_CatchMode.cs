using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_CatchMode : MonoBehaviour
{
    public GameObject catchPlane;
    
    // Start is called before the first frame update
    void Start()
    {      
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            //Debug.Log("you pressed the shit");
        }
        
        RotatePlane();
    }

    public void RotatePlane()
    {
        catchPlane.transform.eulerAngles += new Vector3(0, 0, -Input.GetAxis("Mouse X") * 5);
    }

}
