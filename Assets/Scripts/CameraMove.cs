using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform playerT;
    public float sensitivity = 1.5f;
    private float _rotationX = 0;
    public float _minVert = -45f;
    public float _maxVert = 45f;

    private void Awake() {
        playerT = transform.parent;
    }

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        _rotationX -=  Input.GetAxis("Mouse Y") * sensitivity;
        _rotationX = Mathf.Clamp(_rotationX, _minVert, _maxVert);
        float delta = Input.GetAxis("Mouse X") * sensitivity;
        float _rotationY = playerT.transform.localEulerAngles.y + delta;

        transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
        playerT.rotation = Quaternion.Euler(0, _rotationY, 0);

    }
}
