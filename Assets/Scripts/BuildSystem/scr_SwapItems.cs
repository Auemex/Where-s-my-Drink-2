using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SwapItems
{
public enum ItemType
{
    Chair,
    Painting,
    TrophyStand,
    Trophy,
    kelpDollarsObject,
}
private scr_Items builder;
private List<HotkeyItem> hotkeyItemList;


public scr_SwapItems(scr_Items builder)
{
    this.builder = builder;
    hotkeyItemList = new List<HotkeyItem>();
    hotkeyItemList.Add(new HotkeyItem { itemType = ItemType.Chair, activateItemAction = () => builder.SetItemType(scr_Items.ItemType.Konch)});
    hotkeyItemList.Add(new HotkeyItem { itemType = ItemType.Chair, activateItemAction = () => builder.SetItemType(scr_Items.ItemType.Drink)});
    hotkeyItemList.Add(new HotkeyItem { itemType = ItemType.Chair, activateItemAction = () => builder.SetItemType(scr_Items.ItemType.Trophy)});
    hotkeyItemList.Add(new HotkeyItem { itemType = ItemType.Chair, activateItemAction = () => builder.SetItemType(scr_Items.ItemType.TrophyStand)});
    hotkeyItemList.Add(new HotkeyItem { itemType = ItemType.Chair, activateItemAction = () => builder.SetItemType(scr_Items.ItemType.Table)});
}
public void Update()
{
        if (Input.GetKeyDown(KeyCode.Alpha1))
            {
        hotkeyItemList[0].activateItemAction();
        Debug.Log("working 1");
            }
        if (Input.GetKeyDown(KeyCode.Alpha2))
                {
        hotkeyItemList[1].activateItemAction();
                Debug.Log("working 2");
        
                }
        if (Input.GetKeyDown(KeyCode.Alpha3))
                {
        hotkeyItemList[2].activateItemAction();
                Debug.Log("working 3");
                }
        if (Input.GetKeyDown(KeyCode.Alpha4))
                {
        hotkeyItemList[3].activateItemAction();
                Debug.Log("working 4");
                }
        if (Input.GetKeyDown(KeyCode.Alpha5))
                {
        hotkeyItemList[4].activateItemAction();
                Debug.Log("working 5");
                }
}
                public List<HotkeyItem> GetHotkeyItems()
                {
                    return hotkeyItemList;
                }
                public class HotkeyItem
                {
                    public ItemType itemType;
                    public Action activateItemAction;
                    public Sprite GetSprite()
                    {
                    switch(itemType)
                        {
                        default:
                        case ItemType.Chair:            return scr_itemAssets.Instance.chairSprite;
                        case ItemType.Painting:         return scr_itemAssets.Instance.paintingSprite;
                        case ItemType.TrophyStand:      return scr_itemAssets.Instance.trophyStandSprite;
                        case ItemType.Trophy:           return scr_itemAssets.Instance.trophySprite;
                        }
                    }
                }
}
