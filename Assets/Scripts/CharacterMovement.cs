using UnityEngine;
using System.Collections.Generic;

public class CharacterMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float RaycastLength = 0.1f;
    public float JumpForce = 2f;
    public int mask = 1 << 3;
    private Rigidbody _rb;
    [SerializeField] GameObject CameraFirst;
    [SerializeField] GameObject CameraThird;
    public bool isGrounded = false;
    private int _runDir;
    private List<SkinnedMeshRenderer> meshes;
    private Anim Anim;
    private void Awake() {
        _rb = GetComponent<Rigidbody>();
        Anim = GetComponent<Anim>();
        meshes = new List<SkinnedMeshRenderer>();
        var skins = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach(SkinnedMeshRenderer skin in skins){
            meshes.Add(skin);
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.C)) CameraSwitch();
        if(Input.GetKeyDown(KeyCode.Space)){
            if(!isGrounded)
                CheckGround();
            if(isGrounded){
                _rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
                isGrounded = false;
                Anim.Jump(true);
            }
        }
    }
    private void FixedUpdate() {
        
        Vector2 _targetVelocity = new Vector2(Input.GetAxis("Horizontal") * Speed, Input.GetAxis("Vertical") * Speed);
        if(isGrounded && _targetVelocity != Vector2.zero){
            _rb.velocity = transform.rotation * new Vector3(_targetVelocity.x, _rb.velocity.y, _targetVelocity.y);
            Anim.SetRunMode(_targetVelocity);
        }
        else{
            Anim.SetRunMode(Vector3.zero, false);
        }
    }

    private void CheckGround(){
        if(Physics.Raycast(transform.position, Vector3.down, RaycastLength, mask))
            isGrounded = true;
        else
            isGrounded = false;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ground"){
            isGrounded = true;
            Anim.Jump(false);
        }
    }

    private void CameraSwitch(){
        CameraFirst.SetActive(!CameraFirst.activeSelf);
        CameraThird.SetActive(!CameraThird.activeSelf);
        if(CameraFirst.activeSelf){
            foreach(SkinnedMeshRenderer mesh in meshes){
                mesh.enabled = false;
            }
        }
        else{
            foreach(SkinnedMeshRenderer mesh in meshes){
                mesh.enabled = true;
            }
        }
    }
}
