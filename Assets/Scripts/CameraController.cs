using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 300;

    public float xRotation;

    private void Start()
    {
        xRotation = 0;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        /*
        if(xRotation < -90)
        {
            xRotation = -90;
        }
        if (xRotation > 90)
        {
            xRotation = 90;
        }
        */
        
        
        
        
        



        //rotate
        transform.parent.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
   
    
}
