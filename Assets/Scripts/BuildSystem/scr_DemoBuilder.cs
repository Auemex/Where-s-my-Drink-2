using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_DemoBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject ItemListt;
    [SerializeField]
    Transform CamChild;

    [SerializeField]
    GameObject FloorBuild;
    [SerializeField]
    GameObject FloorPrefab;
    [SerializeField]
    public bool canBuild;
    public bool canBuildCamera;
    public bool insidehouse;
    [SerializeField]
    GameObject destination;
    [SerializeField]
    LayerMask floorMask;
    [SerializeField]
    LayerMask wallMask;
    Renderer rend;
    [SerializeField]
    GameObject uiElement1;
       [SerializeField]
    GameObject uiElement2;
       [SerializeField]
    GameObject uiElement3;

    private int object1;
    bool object1Selected;
    private int object2;
    bool object2Selected;
    private int object3;
    bool object3Selected;
    float itemslotTemplate2x;
    float itemslotTemplate3x;

    public GameObject uiInventory;

    // Start is called before the first frame update
void Start()
    {
        // rectransforms for uiElements
        RectTransform recttransform1 = uiElement2.GetComponent<RectTransform>();
        RectTransform recttransform2 = uiElement3.GetComponent<RectTransform>();
        itemslotTemplate2x = recttransform1.anchoredPosition.x;
        itemslotTemplate3x = recttransform2.anchoredPosition.x;
        
        // amount of items in hand
        object1 = 1;
        object2 = 1;
        object3 = 1;
        // can place
        object1Selected = false;
        object2Selected = false;
        object3Selected = false;
        //
        insidehouse = false;
        canBuild = true;
        canBuildCamera = false;
        rend = FloorBuild.GetComponent<Renderer>();
    }
   void Update()
   {
    FloorBuild.transform.position = destination.transform.position;
    FloorBuild.transform.rotation = destination.transform.rotation;
    //Debug.Log("object1: " + object1);
    //Debug.Log("object2: " + object2);
    //Debug.Log("object3: " + object3);
        //scr_itemAssets playerHousingitemList = GameObject.Find(ItemAssets).GetComponent<scr_itemAssets>();
        
        if (insidehouse /*&& canBuildCamera*/)
        {
            //uiInventory.gameObject.SetActive(true);
            RaycastFloor();
            if (Input.GetKeyDown(KeyCode.R))
                {
                //Debug.Log("you pressed R: " + canBuildCamera);

                canBuildCamera = false;
                destination.SetActive(false);
                }
        }
        else if (insidehouse /*&& !canBuildCamera*/) 
            {
            //uiInventory.gameObject.SetActive(false);
            HouseStop();
            if (Input.GetKeyDown(KeyCode.R))
                {
                    //Debug.Log("you pressed R: " +canBuildCamera);

                    canBuildCamera = true;
                    destination.SetActive(true);
                    //HouseStop();
                }
            }
    }

    void RaycastFloor()
    {
        if(Input.GetMouseButtonDown(0) && canBuild)
            {
            //Instantiate(FloorPrefab, FloorBuild.transform.position, FloorBuild.transform.rotation);
            if (object1Selected)
            {
                object1 = object1 - 1;
                Instantiate(FloorPrefab, FloorBuild.transform.position, FloorBuild.transform.rotation);
                object1Selected = false;
                Destroy(uiElement1);
            if (uiElement2)
            {
            //Debug.Log("working");
            RectTransform recttransform1 = uiElement2.GetComponent<RectTransform>();
            recttransform1.anchoredPosition = new Vector2 ((itemslotTemplate2x -149f), -1f);
            }
            if (uiElement3)
            {
            //Debug.Log("working2");
            RectTransform recttransform2 = uiElement3.GetComponent<RectTransform>();
            recttransform2.anchoredPosition = new Vector2 ((itemslotTemplate3x - 149f), -1);
            itemslotTemplate3x = itemslotTemplate3x - 149f;
            }
            }
            if (object2Selected)
            {
                object2 = object2 -1;
                Instantiate(FloorPrefab, FloorBuild.transform.position, FloorBuild.transform.rotation);
                object2Selected = false;
                Destroy(uiElement2);
            if (uiElement3)
            {
            //Debug.Log("working3");
            RectTransform recttransform2 = uiElement3.GetComponent<RectTransform>();
           recttransform2.anchoredPosition = new Vector2 ((itemslotTemplate3x - 149f),-1);
           itemslotTemplate3x = itemslotTemplate3x - 149f;
            }

            }
            if (object3Selected)
            {
                object3 = object2 - 1;
                Instantiate(FloorPrefab, FloorBuild.transform.position, FloorBuild.transform.rotation);
                object3Selected = false;
                Destroy(uiElement3);
            }
            HouseStop();
            }
        if (Input.GetKeyDown(KeyCode.Alpha1) && object1 > 0)
            {
            object1Selected = true;
            object2Selected = false;
            object3Selected = false;
            FloorBuild = ItemListt.GetComponent<scr_itemAssets>().konchObject;
            FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().konchPrefab;
            HouseStop();
            ItemListt.GetComponent<scr_itemAssets>().konchObject.SetActive(true);
            Debug.Log("working");
            }
        if (Input.GetKeyDown(KeyCode.Alpha2) && object2 > 0)
                {
            object1Selected = false;
            object2Selected = true;
            object3Selected = false;
            FloorBuild = ItemListt.GetComponent<scr_itemAssets>().drinkObject;
            FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().drinkPrefab;
            HouseStop();
            ItemListt.GetComponent<scr_itemAssets>().drinkObject.SetActive(true);
                //Debug.Log("working");
                }
            if (Input.GetKeyDown(KeyCode.Alpha3) && object3 > 0)
                {
            object1Selected = false;
            object2Selected = false;
            object3Selected = true;
                FloorBuild = ItemListt.GetComponent<scr_itemAssets>().tableObject;
                FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().tablePrefab;
                HouseStop();
                ItemListt.GetComponent<scr_itemAssets>().tableObject.SetActive(true);
                //Debug.Log("working");
                }
            /*if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                FloorBuild = ItemListt.GetComponent<scr_itemAssets>().trophyObject;
                FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().trophyPrefab;
                HouseStop();
                ItemListt.GetComponent<scr_itemAssets>().trophyObject.SetActive(true);
                //Debug.Log("working");
                }
            if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                FloorBuild = ItemListt.GetComponent<scr_itemAssets>().trophyStandObject;
                FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().trophyStandPrefab;
                HouseStop();
                ItemListt.GetComponent<scr_itemAssets>().trophyStandObject.SetActive(true);
                //Debug.Log("working");
                }*/
    }
    //void RaycastWall() {}
    void HouseStop()
    {
                ItemListt.GetComponent<scr_itemAssets>().trophyStandObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().konchObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().drinkObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().trophyObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().tableObject.SetActive(false);
    }

}
