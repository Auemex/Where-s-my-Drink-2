using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PlayerController : MonoBehaviour
{
    // movement
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    // inflatable pants mechanic
    public bool isfloating;
    public float floatStrength = 3.5f;
    //public float heat = 0;
    //public float cold;

    // inventory
    [SerializeField]
    private scr_UI_Inventory uiInventory;
    private scr_Inventory inventory;
    // catchmode
    [SerializeField]
    private scr_CatchMode catchMode;
    [SerializeField]
    private bool catchModeOn;
    [SerializeField]
    GameObject cameraMover;
       void Start()
    {
        
        // getting components
        controller = GetComponent<CharacterController>();
        // float mechanic
        isfloating = false;
        // inventory system
        inventory = new scr_Inventory();
        uiInventory.SetInventory(inventory);
        catchModeOn = false;
        //enteredTrigger = false;
    }
void Update()
    {
        // movement
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right *x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        
        // pants mechanic
        if (!isfloating)
        {
        if (Input.GetButtonDown("Fire3"))
        {
            isfloating = true;
            Debug.Log("is floating = " + isfloating);
        }
        }
        else if (isfloating)
        {
        if(Input.GetButtonDown("Fire3"))
        {
            isfloating = false;
        }    
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(floatStrength * -2f * gravity);
        }
        }
        if (isfloating == false)
        {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if (Input.GetButtonDown("Fire2"))
        {
            if (catchModeOn == false)
            {
                CatchModeInitiate();
            }
            else
            {
            catchMode.GetComponent<scr_CatchMode>().catchPlane.SetActive(false);
            catchModeOn = false;
            cameraMover.transform.localPosition = new Vector3 (0f,1.5f,-2.33f);
            Time.timeScale = 1f;
            }
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        scr_BuildSystem b = GameObject.FindGameObjectWithTag("Builder").GetComponent<scr_BuildSystem>();
        if (other.tag == "House")
        {
            b.insidehouse = true;
            Debug.Log("Inside House");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        scr_BuildSystem b = GameObject.FindGameObjectWithTag("Builder").GetComponent<scr_BuildSystem>();
        if (other.tag == "House")
        {
            b.insidehouse = false;
            Debug.Log("Outside House");
        }
    }

    public void CatchModeInitiate()
    {
    catchMode.GetComponent<scr_CatchMode>().catchPlane.SetActive(true);
    catchModeOn = true;
    cameraMover.transform.localPosition = new Vector3 (0.65f,1.9f,-1f);
    Time.timeScale = 0.5f;
    
    }


}
