using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPointInBox : MonoBehaviour
{
    [Header("Objects")]
    public GameObject[] decals;
    public Vector3 boxToSpawn;
    public GameObject maxPoint;

    private void Start()
    {
        foreach (GameObject gameObject in decals)
        {
            boxToSpawn = GetComponent<BoxCollider>().bounds.size;

            Vector3 randomPos = new Vector3(
                Random.Range(-boxToSpawn.x / 2, boxToSpawn.x / 2),
                boxToSpawn.y = 0.054f,
                Random.Range(-boxToSpawn.z / 2, boxToSpawn.z / 2)
            );
            GameObject spawnedObject = Instantiate(gameObject, transform.position + randomPos, Quaternion.identity);

        }
    }
}
