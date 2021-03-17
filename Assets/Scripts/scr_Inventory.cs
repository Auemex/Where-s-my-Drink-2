using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Inventory
{
    public event EventHandler OnItemListChanged;
    private List<scr_Items> itemList;

    public scr_Inventory()
    {
        itemList = new List<scr_Items>();
        AddItem(new scr_Items {itemType = scr_Items.ItemType.Trophy,amount = 1});
        AddItem(new scr_Items{itemType = scr_Items.ItemType.Painting,amount = 1});
        AddItem(new scr_Items {itemType = scr_Items.ItemType.Chair,amount = 1});
        Debug.Log(itemList.Count);
    }

    public void AddItem (scr_Items item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<scr_Items> GetItemList()
    {
        return itemList;
    }
}
