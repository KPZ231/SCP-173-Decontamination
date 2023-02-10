using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public GameObject UI;
    private void Awake()
    {
        
        Instance = this; 
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            UI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (items.Count >= 10)
        {
            Debug.LogWarning("Cannot Get More Items Into Inventroy");
            items.Clear();
        }
    }

    public void ListImtes()
    {
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var icon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            icon.sprite = item.icon;
        }
    }

}
