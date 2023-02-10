using UnityEngine;

public class FreeCam : MonoBehaviour
{
    public float speed = 10.0f;
    public float mouseSensitivity = 100.0f;
    public float smoothTime = 0.3f;

    float rotY = 0.0f;
    float rotX = 0.0f;

    Vector3 velocity = Vector3.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position = Vector3.SmoothDamp(transform.position,
                            transform.position + transform.right * horizontal + transform.forward * vertical,
                            ref velocity, smoothTime);

        rotY += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotX += -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, -89.0f, 89.0f);

        transform.eulerAngles = new Vector3(rotX, rotY, 0.0f);

        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += transform.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position -= transform.up * Time.deltaTime * speed;
        }
    }
}
