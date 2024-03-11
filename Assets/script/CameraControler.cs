using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{


    [SerializeField] Transform followTarget;

    [SerializeField] float rotationSpeed = 2.0f;
    [SerializeField] float distance = 5.0f;

    [SerializeField] Vector2 framingOffset;

    [SerializeField] float minVerticalAngle = -20.0f;
    [SerializeField] float maxVerticalAngle = 45.0f;

    [SerializeField] bool inverX;
    [SerializeField] bool inverY;

    float rotationX;
    float rotationY;

    float invertXVal;
    float invertYVal;
     void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        invertXVal = (inverX) ? -1 : 1;
        invertYVal = (inverY) ? -1 : 1;

        rotationX += Input.GetAxis("Mouse Y") * invertYVal * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);
        rotationY += Input.GetAxis("Mouse X") * invertXVal * rotationSpeed;

        var targetRotation = Quaternion.Euler(rotationX, rotationY,0.0f);

        var focusPosition = followTarget.position + (Vector3)framingOffset;

        transform.position = focusPosition - targetRotation * new Vector3(0.0f,0.0f, distance);

        transform.rotation = targetRotation;


    }
}
