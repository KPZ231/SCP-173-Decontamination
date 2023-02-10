using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Item item;
    public void Pickup()
    {         
        InventoryManager.Instance.Add(item);
        InventoryManager.Instance.ListImtes();
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        Debug.DrawRay(ray.origin, ray.direction * 3.5f, Color.green);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3.5f))
        {
            if (hit.collider.CompareTag("Pickable"))
            {  
                if (Input.GetKeyDown(KeyCode.E))
                {
                    FindObjectOfType<Sway>().enabled = true;
                    FindObjectOfType<AudioManager>().Play("Pickup_1");
                    hit.transform.gameObject.SetActive(false);
                    Pickup();
                    UseBroom();
                }
            }
            
        }
    }

    string currentItem;

    void UseBroom()
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
