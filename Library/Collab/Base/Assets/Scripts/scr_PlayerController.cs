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
    public LayerMask houseFloorMask;
    public GameObject PauseCanvas;
    public bool isPaused = false;
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
    
    public bool catchModeOn;
    [SerializeField]
    GameObject cameraMover;
    public Animator p_animator;

       void Start()
    {
        
        // getting components
        controller = GetComponent<CharacterController>();
        // float mechanic
        isfloating = false;
        // inventory system
        //inventory = new scr_Inventory();
        //uiInventory.SetInventory(inventory);
        catchModeOn = false;

        //enteredTrigger = false;
    }
        void Update()
    {
        
        //Pausing
        if (Input.GetKeyDown("escape") && isPaused == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
            isPaused = true;
        }
        
        else if (Input.GetKeyDown("escape") && isPaused == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            PauseCanvas.SetActive(false);
            isPaused = false;
        }
        
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
        
        if (Input.GetButtonDown("Fire2") && isPaused == false)
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
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            p_animator.SetBool("isRunning",true);
        }
        else
        {
            p_animator.SetBool("isRunning", false);
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
