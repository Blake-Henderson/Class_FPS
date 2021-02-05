using UnityEngine;

public class LookController : MonoBehaviour
{
    public float lookSensitivity = 2;
    public float lookSmoothDampTime = 0.1f;

    GameObject player;
    float minVerticalLookAngle = -45;
    float maxVerticalLookAngle = 45;
    float rotationY;
    float lookY = 0.0f;

    void Start()
    {
        player = transform.parent.gameObject;        
    }

    void Update()
    {
        rotationY += Input.GetAxis("Mouse Y") * lookSensitivity;
        rotationY = Mathf.Clamp(rotationY, minVerticalLookAngle, maxVerticalLookAngle);

        float currentVelocity = 0.0f;
        player.transform.RotateAround(transform.position, 
            Vector3.up, Input.GetAxis("Mouse X") * lookSensitivity);

        lookY = Mathf.SmoothDamp(lookY, rotationY, ref currentVelocity, lookSmoothDampTime);
        transform.localEulerAngles = new Vector3(-lookY, 0, 0);
    }
}
