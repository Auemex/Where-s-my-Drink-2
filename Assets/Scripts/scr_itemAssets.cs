using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_itemAssets : MonoBehaviour
{
 public static scr_itemAssets Instance {get; private set;}
 private void Awake()
 {
     Instance = this;
 }
public Transform pfItemWorld;
 public Sprite kelpDollarsSprite;
 public Sprite chairSprite;
 public Sprite paintingSprite;
 public Sprite trophySprite;
 public Sprite trophyStandSprite;
 
public GameObject kelpDollarsObject;
 public GameObject chairObject;
 public GameObject paintingObject;
 public GameObject trophyObject;
 public GameObject trophyStandObject;

 public GameObject kelpDollarsPrefab;
 public GameObject chairPrefab;
 public GameObject paintingPrefab;
 public GameObject trophyPrefab;
 public GameObject trophyStandPrefab;

}
