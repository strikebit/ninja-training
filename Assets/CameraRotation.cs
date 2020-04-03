using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotateX;
    public float rotateY;
    public float rotationX;
    public float rotationY;
    void Start()
    {

    }
    void LateUpdate()
    {
        if (Input.GetAxis("Mouse X") < 0)
        {
            rotationX -= rotateX;
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            rotationX += rotateX;
        }
        if (Input.GetAxis("Mouse Y") < 0 && rotationY > -90)
        {
            rotationY -= rotateY;
        }
        if (Input.GetAxis("Mouse Y") > 0 && rotationY < 90)
        {
            rotationY += rotateY;
        }
        if (rotationX > 360 || rotationX < -360)
        {
            rotationX = 0;
        }
        transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0);
    }
}