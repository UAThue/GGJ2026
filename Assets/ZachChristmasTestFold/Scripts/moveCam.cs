using UnityEngine;

public class moveCam : MonoBehaviour
{
    public float sensitivity = 2f;
    private float xRotation = 0f;

    // Update is called once per frame

    //moves the camera to the specified position
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.parent.Rotate(Vector3.up * mouseX);

    }
}
