using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class scr_CatchMode : MonoBehaviour
{    
    
    private Animator anim;
    public GameObject work;
    public GameObject BenjiCatch;
    public GameObject BenjiDefault;
    
    public Transform startMarker;
    public Transform endMarker;
    
    public float speed;

    private Transform currentTransform;
    private bool swipePath;
    
    [SerializeField]
    public GameObject catchPlane;
    public bool catchModeOn;
    
    void Start()
    {      
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GetComponent<scr_PlayerController>();
        anim = GameObject.Find("JellyfishingHelp").GetComponent<Animator>();
        catchPlane.gameObject.SetActive(false);
        BenjiCatch.gameObject.SetActive(false);
        swipePath = true;
        currentTransform = startMarker;

    }

    void Update()
    {
        //work.transform.position = new Vector3 (catchPlane.transform.GetChild(0).position.x,catchPlane.transform.GetChild(0).position.y, catchPlane.transform.GetChild(0).position.z);   
        //anim.SetFloat("x", Mathf.Clamp(catchPlane.transform.GetChild(0).localPosition.x + 0.3f,-1,1));
        //anim.SetFloat("y", Mathf.Clamp(catchPlane.transform.GetChild(0).localPosition.y + .18f, -1,1));     
        
        anim.SetFloat("x", Mathf.Clamp(work.transform.localPosition.x + 0.3f, -1, 1));
        anim.SetFloat("y", Mathf.Clamp(work.transform.localPosition.y + .18f, -1, 1));
        
        if (Input.GetMouseButtonDown(1))
        {
            
            if (catchModeOn == false)
            {
                //transform.rotation = Quaternion.Lerp(transform.rotation,Camera.main.transform.rotation,.2f);
                CatchModeInitiate();
                
            }

        }

        if (Input.GetMouseButtonUp(1))
            {
            BenjiDefault.gameObject.SetActive(true);
            catchPlane.gameObject.SetActive(false);
            BenjiCatch.gameObject.SetActive(false);
            catchModeOn = false;
            Time.timeScale = 1f;
            }

        if (catchModeOn == true) 
        {
           if (swipePath) 
           {
                work.transform.position = new Vector3 (catchPlane.transform.GetChild(0).position.x,catchPlane.transform.GetChild(0).position.y, catchPlane.transform.GetChild(0).position.z);
                
                if(Input.GetMouseButtonDown(0)){


                
                Debug.Log("dat shit bussin'");
                
                swipePath = false;

                currentTransform = endMarker;
    
                //work.transform.localPosition = Vector3.Lerp(work.transform.localPosition, currentTransform.localPosition, Time.deltaTime * speed);
                
                //work.transform.position = new Vector3(work.transform.position.x * -1, work.transform.position.y, work.transform.position.z);
                //catchPlane.transform.GetChild(0).position = new Vector3(catchPlane.transform.GetChild(0).position.x * -1, catchPlane.transform.GetChild(0).position.y * -1, catchPlane.transform.GetChild(0).position.z);
            }                
           }

           else if (swipePath == false) 
           {
                work.transform.position = new Vector3 (catchPlane.transform.GetChild(1).position.x,catchPlane.transform.GetChild(1).position.y, catchPlane.transform.GetChild(1).position.z);
                
                if(Input.GetMouseButtonDown(0)){


                
                Debug.Log("dat shit bussin'");
                
                swipePath = true;

                currentTransform = endMarker;
    
                //work.transform.localPosition = Vector3.Lerp(work.transform.localPosition, currentTransform.localPosition, Time.deltaTime * speed);
                
                //work.transform.position = new Vector3(work.transform.position.x * -1, work.transform.position.y, work.transform.position.z);
                //catchPlane.transform.GetChild(0).position = new Vector3(catchPlane.transform.GetChild(0).position.x * -1, catchPlane.transform.GetChild(0).position.y * -1, catchPlane.transform.GetChild(0).position.z);
                }
            }  
        }
        RotatePlane();
    }
    
    public void RotatePlane()
    {
        catchPlane.transform.eulerAngles += new Vector3(0, 0, -Input.GetAxis("Mouse X") * 5);
    }

    public void CatchModeInitiate()
    {
    BenjiDefault.gameObject.SetActive(false);
    BenjiCatch.gameObject.SetActive(true);
    catchPlane.gameObject.SetActive(true);
    catchModeOn = true;
    Time.timeScale = 0.2f;
    }
}