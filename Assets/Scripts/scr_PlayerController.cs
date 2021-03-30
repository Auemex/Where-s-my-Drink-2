using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

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
    public GameObject MainCamera;
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

    public Animator p_animator;
    public Animator pants_animator;

    void Start()
    {
        
        // getting components
        controller = GetComponent<CharacterController>();
        // float mechanic
        isfloating = false;
        pants_animator.SetBool("isInflated", false);

        MainCamera.gameObject.SetActive(true);   
        
        // inventory system
        //inventory = new scr_Inventory();
        //uiInventory.SetInventory(inventory);
        // catchmode

        //scr_NpcShop.SpawnItemWorld(new Vector3(20, 5, 20), new scr_Items {itemType = scr_Items.ItemType.Konch, amount = 1});
        //scr_NpcShop.SpawnItemWorld(new Vector3(-20, 5, 20), new scr_Items {itemType = scr_Items.ItemType.Drink, amount = 1});
        //scr_NpcShop.SpawnItemWorld(new Vector3(0, 5, -20), new scr_Items {itemType = scr_Items.ItemType.Table, amount = 1});

        //enteredTrigger = false;

        GetComponent<scr_CatchMode>();
        
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
        Vector3 move = Camera.main.transform.right * x + Camera.main.transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // pants mechanic
        if (!isfloating)
        {
        if (Input.GetButtonDown("Fire3"))
        {
            isfloating = true;
            Debug.Log("is floating = " + isfloating);
            pants_animator.SetBool("isInflated", false);
        }
        }
        else if (isfloating)
        {
        if(Input.GetButtonDown("Fire3"))
        {
            isfloating = false;
            pants_animator.SetBool("isInflated", true);
            Debug.Log ("is floating = " + isfloating);
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
        
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            p_animator.SetBool("isRunning", true);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
            //playerBody.transform.Rotate(0f,Camera.main.transform.rotation.y,0f);
            //transform.localRotation = Quaternion.Euler(0f, Camera.main.transform.forward, 0f);
        }
        else
        {
            p_animator.SetBool("isRunning", false);
        }
        /*if (isfloating == true)
        {
            p_animator.SetBool("isInflated", true);
        }*/


    }
    public void OnTriggerEnter(Collider other)
    {
        scr_NpcShop itemworld = other.GetComponent<scr_NpcShop>();
        scr_DemoBuilder b = GameObject.FindGameObjectWithTag("Builder").GetComponent<scr_DemoBuilder>();
        if (other.tag == "House")
        {
            b.insidehouse = true;
            Debug.Log("Inside House");
        }
        if (itemworld !=null)
        {
            //inventory.AddItem(itemworld.GetItems());
            //itemworld.DestroySelf();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        scr_DemoBuilder b = GameObject.FindGameObjectWithTag("Builder").GetComponent<scr_DemoBuilder>();
        if (other.tag == "House")
        {
            b.insidehouse = false;
            Debug.Log("Outside House");
        }
    }
}