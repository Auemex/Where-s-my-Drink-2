using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_HB_CollisionCheck : MonoBehaviour
{
    [SerializeField]
    Material canBuild;
    [SerializeField]
    Material cantBuild;
    [SerializeField]
    Renderer rend;
    void Start()
    {
       // rend = GetComponent<Renderer>();
    }
    void OnTriggerStay(Collider other)
    {
       scr_DemoBuilder b = GameObject.FindGameObjectWithTag("Builder").GetComponent<scr_DemoBuilder>();
        if (other.tag == "HouseObjects")
        {
            b.canBuild = false;
            rend.material = cantBuild;
            Debug.Log("b.canBuild = " + b.canBuild);

        }
        //if (other.tag == "")
        //{}
    }
        void OnTriggerExit(Collider other)
    {
        scr_DemoBuilder b = GameObject.FindGameObjectWithTag("Builder").GetComponent<scr_DemoBuilder>();
        if (other.tag == "HouseObjects")
        {
            b.canBuild = true;
            rend.material = canBuild;
            Debug.Log("b.canBuild = " + b.canBuild);
        }
    }
}
