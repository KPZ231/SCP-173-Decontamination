using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public Item item;

    public string currentItem;

    public void UseItem()
    {
        switch (item.type)
        {
            case Item.ItemType.Broom:
                UseBroom(); 
                break;
        }
    }


    public void UseBroom()
    {
        currentItem = "Broom";
        GameObject obj = GameObject.Find("BroomHead");
        obj.SetActive(true);
        obj.transform.GetChild(0).gameObject.SetActive(true);
        obj.transform.position = GameObject.Find("BroomHeldPoint").transform.position;
        obj.transform.parent = GameObject.Find("BroomHeldPoint").transform;
        obj.transform.rotation = GameObject.Find("BroomHeldPoint").transform.rotation;
        if (currentItem == "Broom")
        {
            FindObjectOfType<CleainngManager>().canClean = true;
        }
        else
        {
            return;
        }
    }
}
