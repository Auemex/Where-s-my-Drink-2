using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class scr_Items
{
    public enum ItemType
    {
        Chair,
        Painting,
        TrophyStand,
        Trophy,
        KelpDollars,
    }

    public ItemType itemType;
    public int amount;

    public GameObject GetObject()
    {
        switch(itemType)
        {
            default:
            case ItemType.Chair:            return scr_itemAssets.Instance.chairObject;
            case ItemType.Painting:         return scr_itemAssets.Instance.paintingObject;
            case ItemType.TrophyStand:      return scr_itemAssets.Instance.trophyStandObject;
            case ItemType.Trophy:           return scr_itemAssets.Instance.trophyObject;
            case ItemType.KelpDollars:      return scr_itemAssets.Instance.kelpDollarsObject;
        }
    }
    public Sprite GetSprite()
    {
        switch(itemType)
        {
            default:
            case ItemType.Chair:            return scr_itemAssets.Instance.chairSprite;
            case ItemType.Painting:         return scr_itemAssets.Instance.paintingSprite;
            case ItemType.TrophyStand:      return scr_itemAssets.Instance.trophyStandSprite;
            case ItemType.Trophy:           return scr_itemAssets.Instance.trophySprite;
            case ItemType.KelpDollars:      return scr_itemAssets.Instance.kelpDollarsSprite;

        }
    }

}
