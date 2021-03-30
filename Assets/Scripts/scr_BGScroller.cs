using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_BGScroller : MonoBehaviour
{
    public float speed;
    Vector3 startPOS;

    void Start()
    {
        startPOS = transform.position;
    }


    void Update()
    {
        transform.Translate((new Vector3(-1, 0, 0)) * speed * Time.deltaTime);
    }
}
