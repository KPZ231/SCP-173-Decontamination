using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnBox : MonoBehaviour
{
    public GameObject[] obj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject gameObj in obj)
            {
                gameObj.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject gameObj in obj)
            {
                gameObj.SetActive(false);
            }
        }
    }
}
