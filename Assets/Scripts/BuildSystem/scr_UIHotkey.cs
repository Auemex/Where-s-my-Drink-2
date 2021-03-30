using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_UIHotkey : MonoBehaviour
{
    private Transform itemSlotTemplate;
    private scr_SwapItems swapItemSystem;

    private void Awake()
    {
        itemSlotTemplate = transform.Find("itemSlotTemplate");
        itemSlotTemplate.gameObject.SetActive(false);
    }
    public void SetHotKeyItemSystem(scr_SwapItems swapItemSystem)
    {
        this.swapItemSystem = swapItemSystem;
        UpdateVisual();

    }
    private void UpdateVisual ()
    {
        List<scr_SwapItems.HotkeyItem> hotkeyItemList = swapItemSystem.GetHotkeyItems();
        for (int i = 0; i < hotkeyItemList.Count; i ++) 
        {
            scr_SwapItems.HotkeyItem hotkeyItem = hotkeyItemList[i];
            Transform abilitySlotTransform = Instantiate(itemSlotTemplate, transform);
            abilitySlotTransform.gameObject.SetActive(true);
            RectTransform abilitySlotRectTransform = abilitySlotTransform.GetComponent<RectTransform>();
            abilitySlotRectTransform.anchoredPosition = new Vector2 (50f * i, 0f);
            abilitySlotTransform.Find("Icon").GetComponent<Image>().sprite = hotkeyItem.GetSprite();
            //abilitySlotTransform.Find("numberText").GetComponent<TMPro.TextMeshProUGUI>().SetText((i+1).ToString()); 
        }
    }
}
