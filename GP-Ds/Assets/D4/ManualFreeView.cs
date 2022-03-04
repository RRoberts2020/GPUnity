using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualFreeView : MonoBehaviour
{

    [SerializeField] private float MouseSensitivity;

    private Transform parent;

    private void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
       Rotate();
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;

        parent.Rotate(Vector3.up, mouseX);
    }

}
