using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform player;
    public float smoothTime = 0.3f;
    private Vector3 smoothVelocity = Vector3.zero;
    public bool invertAxis = false;

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, smoothTime * Time.deltaTime);
    }

    public void LookAtPlayer()
    {
        Vector3 direction = player.position - transform.position;
        if (invertAxis) direction = -direction;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, smoothTime * Time.deltaTime);
    }
}
