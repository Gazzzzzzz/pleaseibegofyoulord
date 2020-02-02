using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private Transform m_Parent = null;



    
    void Update()
    {
        CameraMove();
    }

    private void CameraMove()
    {
        
        float mouseMoveX = Input.GetAxis("Mouse X");
        float mouseMoveY = -Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.right, mouseMoveY * Time.deltaTime * 250f);
        m_Parent.Rotate(Vector3.up, mouseMoveX * Time.deltaTime * 250f);

        Vector3 rotation = transform.localRotation.eulerAngles;
        if (rotation.x >= 180)
        {
            rotation.x -= 360f;
        }
        rotation.x = Mathf.Clamp(rotation.x, -50, 50);
        rotation.z = 0f;

        transform.localRotation = Quaternion.Euler(rotation);
    }

   
}
