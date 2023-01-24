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
                    hit.transform.gameObject.SetActive(false);
                    Pickup();

                }
            }
            
        }
    }
}
