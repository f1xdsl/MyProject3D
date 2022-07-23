using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMove3rd : MonoBehaviour
{
    private Transform playerT;
    private Transform headT;
    public float HorSensitivity;
    public float VertSensitivity;
    private float _rotationX = 0;
    public float MinVert;
    public float MaxVert;


    private void Awake() {
        HorSensitivity = 1.5f;
        VertSensitivity = 150f;
        MinVert = 315f;
        MaxVert = 45f;

        playerT = transform.parent;
        headT = GameObject.Find("HeadRot").transform;
    }

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {   
        _rotationX = Input.GetAxis("Mouse Y") * HorSensitivity;
        float _tr = transform.rotation.eulerAngles.x + _rotationX;
        
        if ((_tr < MinVert) && (_tr > MaxVert))
        {
            _rotationX = 0;
        }

        float delta = Input.GetAxis("Mouse X") * HorSensitivity;
        float _rotationY = playerT.transform.localEulerAngles.y + delta;

        transform.RotateAround(headT.position, headT.right, _rotationX);
        playerT.rotation = Quaternion.Euler(0, _rotationY, 0);

    }
}
