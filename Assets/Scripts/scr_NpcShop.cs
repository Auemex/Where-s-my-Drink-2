using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_NpcShop : MonoBehaviour
{
public static scr_NpcShop SpawnItemWorld (Vector3 position,scr_Items items)
{
    Transform transform = Instantiate(scr_itemAssets.Instance.pfItemWorld, position, Quaternion.identity);

    scr_NpcShop itemWorld = transform.GetComponent<scr_NpcShop>();
    itemWorld.SetItem(items);

    return itemWorld;
}
    private scr_Items items;
    public void SetItem(scr_Items item)
    {
        this.items = item;
        //meshfilter.mesh = item.GetObject();
    }
}
