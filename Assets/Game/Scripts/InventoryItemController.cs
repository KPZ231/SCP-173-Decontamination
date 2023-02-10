using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    public Item item;
    public Item item_2;

    public string currentItem;

    private void Update()
    {
        if(item_2.type == Item.ItemType.Keycard)
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void UseItem()
    {
        if(item.type == Item.ItemType.Broom)
        {
            UseBroom();
        }           
    }

    public void UseCard()
    {
        Debug.Log("Card");
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
