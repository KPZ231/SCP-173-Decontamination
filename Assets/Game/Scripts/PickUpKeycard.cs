using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKeycard : MonoBehaviour
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
            if (hit.collider.CompareTag("Keycard_Lvl_1"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {                                    
                    FindObjectOfType<AudioManager>().Play("Pickup_1");
                    hit.transform.gameObject.SetActive(false);
                    Pickup();

                }
            }

        }
    }
}
