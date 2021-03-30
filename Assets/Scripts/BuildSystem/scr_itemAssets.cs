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
//public Transform pfItemWorld;
 public Sprite kelpDollarsSprite;
 public Sprite chairSprite;
 public Sprite paintingSprite;
 public Sprite trophySprite;
 public Sprite trophyStandSprite;
 
public GameObject konchObject;
 public GameObject tableObject;
 public GameObject drinkObject;
 public GameObject trophyObject;
 public GameObject trophyStandObject;

 public GameObject konchPrefab;
 public GameObject tablePrefab;
 public GameObject drinkPrefab;
 public GameObject trophyPrefab;
 public GameObject trophyStandPrefab;

 public Mesh kelpDollarsMesh;
public Mesh  chairMesh;
public Mesh paintingMesh;
public Mesh trophyMesh;
public Mesh trophyStandMesh;

}
