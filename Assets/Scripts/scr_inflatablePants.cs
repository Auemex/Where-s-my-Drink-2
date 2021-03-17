using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_inflatablePants : MonoBehaviour
{
   
    public CharacterController controller;
    public float speed = 12f;
    public bool isfloating;
    public float floatStrength = 3.5f;
    public float gravity = -9.81f;
    //public float heat = 0;
    //public float cold;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        isfloating = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right *x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Fire3"))
        {
            isfloating = true;
            Debug.Log("is floating = " + isfloating);
        }
        /*if((Input.GetButtonDown("Fire3")) && (isfloating))
        {
            isfloating = false;
            Debug.Log("is floating = " + isfloating);
        }*/
        if((Input.GetButtonDown("Jump")) && (isfloating))
        {
            velocity.y = Mathf.Sqrt(floatStrength * -2f * gravity);
        }
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
