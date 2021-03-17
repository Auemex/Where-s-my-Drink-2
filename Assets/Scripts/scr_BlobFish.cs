using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_BlobFish : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {
        //scr_PlayerController p = GameObject.FindGameObjectWithTag("Player").GetComponent<scr_PlayerController>();
        if (Input.GetMouseButton(0) && other.tag == "CatchPlane")
        {
            Destroy(gameObject);
            Debug.Log("oh no I die :(");
        }
    }
}
