using UnityEngine;

public class Rqaycast_Indicator : MonoBehaviour
{
    public GameObject interactImage;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        Debug.DrawRay(ray.origin, ray.direction * 3.5f, Color.green);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3.5f))
        {
            if (hit.collider.CompareTag("Pickable") || hit.collider.CompareTag("Door")
                || hit.collider.CompareTag("Broom") || hit.collider.CompareTag("Door_Button_2") || hit.collider.CompareTag("Keycard_Lvl_1_Door")
                || hit.collider.CompareTag("Keycard_Lvl_1") || hit.collider.CompareTag("Cont_Door") || hit.collider.CompareTag("Shutters"))
            {
                interactImage.SetActive(true);               
            }
            else
            {
                interactImage.SetActive(false);
            }
        }
    }
}
