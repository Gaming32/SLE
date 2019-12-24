using UnityEngine;

public class MouseOrbit : MonoBehaviour
{
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -90F;
    public float maximumY = 90F;
    float rotationX = 0F;
    float rotationY = 0F;
    Quaternion originalRotation;
    void Update()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            // Read the mouse input axis
            rotationX = Input.GetAxis("Mouse X") * sensitivityX;
            rotationY = Input.GetAxis("Mouse Y") * sensitivityY;
            transform.RotateAround(Vector3.zero, transform.up, rotationX);
            transform.RotateAround(Vector3.zero, transform.right, rotationY);
            transform.LookAt(Vector3.zero);
        }
        else if (axes == RotationAxes.MouseX)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
            transform.localRotation = originalRotation * yQuaternion;
        }
    }
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        // Make the rigid body not change rotation
        if (rigidbody)
            rigidbody.freezeRotation = true;
        originalRotation = transform.localRotation;
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
         angle += 360F;
        if (angle > 360F)
         angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
