using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class scr_Items
{
    public enum ItemType
    {
        Konch,
        Drink,
        TrophyStand,
        Trophy,
        Table,
    }

    public ItemType itemType;
    public int amount;

    public GameObject GetObject()
    {
        switch(itemType)
        {
            default:
            case ItemType.Konch:            return scr_itemAssets.Instance.konchObject;
            case ItemType.Drink:            return scr_itemAssets.Instance.drinkObject;
            case ItemType.TrophyStand:      return scr_itemAssets.Instance.trophyStandObject;
            case ItemType.Trophy:           return scr_itemAssets.Instance.trophyObject;
            case ItemType.Table:            return scr_itemAssets.Instance.tableObject;
        }
    }
    public Sprite GetSprite()
    {
        switch(itemType)
        {
            default:
            case ItemType.Konch:            return scr_itemAssets.Instance.chairSprite;
            case ItemType.Drink:         return scr_itemAssets.Instance.paintingSprite;
            case ItemType.TrophyStand:      return scr_itemAssets.Instance.trophyStandSprite;
            case ItemType.Trophy:           return scr_itemAssets.Instance.trophySprite;
            case ItemType.Table:      return scr_itemAssets.Instance.kelpDollarsSprite;

        }
    }
    public Mesh GetMesh()
    {
        switch(itemType)
        {
            default:
            case ItemType.Konch:            return scr_itemAssets.Instance.chairMesh;
            case ItemType.Drink:         return scr_itemAssets.Instance.paintingMesh;
            case ItemType.TrophyStand:      return scr_itemAssets.Instance.trophyStandMesh;
            case ItemType.Trophy:           return scr_itemAssets.Instance.trophyMesh;
            case ItemType.Table:      return scr_itemAssets.Instance.kelpDollarsMesh;

        }
    }

    public GameObject SetItemType(ItemType itemType)
    {
        switch(itemType)
        {
            default:
            case ItemType.Konch:            return scr_itemAssets.Instance.konchObject;
            case ItemType.Drink:         return scr_itemAssets.Instance.drinkObject;
            case ItemType.TrophyStand:      return scr_itemAssets.Instance.trophyStandObject;
            case ItemType.Trophy:           return scr_itemAssets.Instance.trophyObject;
            case ItemType.Table:      return scr_itemAssets.Instance.tableObject;

        }
    }

}
