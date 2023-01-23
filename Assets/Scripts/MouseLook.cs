using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    Transform playerBody;

    public float mouseSensitivity = 180f;

    float yRotation = 0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Vector2 _mouseLook = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        yRotation -= _mouseLook.y;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

       
        transform.localRotation = Quaternion.Euler(yRotation,0, 0);
        playerBody.Rotate(Vector3.up * _mouseLook.x * mouseSensitivity * Time.deltaTime);
    }
}
