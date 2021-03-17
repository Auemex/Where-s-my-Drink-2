using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_BuildSystem : MonoBehaviour
{
    [SerializeField]
    GameObject ItemListt;
    [SerializeField]
    Transform CamChild;

    [SerializeField]
    //Transform [] FloorBuild;
    GameObject FloorBuild;
    //[SerializeField]
    //int transformPoints;

    [SerializeField]
    //Transform [] FloorPrefab;
    GameObject FloorPrefab;
    //[SerializeField]
    //int prefabPoints;

    public bool insidehouse;
    RaycastHit Hit;
    // Start is called before the first frame update
    void Start()
    {
        insidehouse = false;
        //FloorBuild = FloorBuild[transformPoints];
        //FloorPrefab = FloorPrefab[transformPoints];
    }

    // Update is called once per frame
    void Update()
    {
        //scr_itemAssets playerHousingitemList = GameObject.Find(ItemAssets).GetComponent<scr_itemAssets>();

        if (insidehouse == true)
        {
        if(Physics.Raycast(CamChild.position,CamChild.forward,out Hit, 6f))
        {
            FloorBuild.transform.position = new Vector3(Mathf.RoundToInt(Hit.point.x) != 0 ? Mathf.RoundToInt(Hit.point.x/3.2f) * 3.2f : 3,
            Mathf.RoundToInt(Hit.point.y)!= 0 ? Mathf.RoundToInt(Hit.point.y/3.2f) * 3.2f : 0 + FloorBuild.transform.localScale.y,
            Mathf.RoundToInt(Hit.point.z)!= 0 ? Mathf.RoundToInt(Hit.point.z/3.2f) * 3.2f : 3);

            FloorBuild.transform.eulerAngles = new Vector3(0,Mathf.RoundToInt(transform.eulerAngles.y) !=0? Mathf.RoundToInt (transform.eulerAngles.y / 90f) * 90 : 0, 0);

            if(Input.GetMouseButtonDown(0))
                {
                Instantiate(FloorPrefab, FloorBuild.transform.position, FloorBuild.transform.rotation);
                }
            if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                FloorBuild = ItemListt.GetComponent<scr_itemAssets>().kelpDollarsObject;
                FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().kelpDollarsPrefab;
                ItemListt.GetComponent<scr_itemAssets>().kelpDollarsObject.SetActive(true);
                ItemListt.GetComponent<scr_itemAssets>().chairObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().paintingObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().trophyObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().trophyStandObject.SetActive(false);
                Debug.Log("working");
                }
            if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                FloorBuild = ItemListt.GetComponent<scr_itemAssets>().chairObject;
                FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().chairPrefab;
                ItemListt.GetComponent<scr_itemAssets>().chairObject.SetActive(true);
                ItemListt.GetComponent<scr_itemAssets>().kelpDollarsObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().paintingObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().trophyObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().trophyStandObject.SetActive(false);
                Debug.Log("working");
                }
            if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                FloorBuild = ItemListt.GetComponent<scr_itemAssets>().paintingObject;
                FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().paintingPrefab;
                ItemListt.GetComponent<scr_itemAssets>().paintingObject.SetActive(true);
                ItemListt.GetComponent<scr_itemAssets>().chairObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().kelpDollarsObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().trophyObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().trophyStandObject.SetActive(false);
                Debug.Log("working");
                }
            if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                FloorBuild = ItemListt.GetComponent<scr_itemAssets>().trophyObject;
                FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().trophyPrefab;
                ItemListt.GetComponent<scr_itemAssets>().trophyObject.SetActive(true);
                ItemListt.GetComponent<scr_itemAssets>().chairObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().paintingObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().kelpDollarsObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().trophyStandObject.SetActive(false);
                Debug.Log("working");
                }
            if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                FloorBuild = ItemListt.GetComponent<scr_itemAssets>().trophyStandObject;
                FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().trophyStandPrefab;
                ItemListt.GetComponent<scr_itemAssets>().trophyStandObject.SetActive(true);
                ItemListt.GetComponent<scr_itemAssets>().chairObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().paintingObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().trophyObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().kelpDollarsObject.SetActive(false);
                Debug.Log("working");
                }
        }
        }
        else
        {
            HouseBuilderOff();
        }
    }

    void HouseBuilderOff ()
    {
                ItemListt.GetComponent<scr_itemAssets>().trophyStandObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().chairObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().paintingObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().trophyObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().kelpDollarsObject.SetActive(false);
    }

}
