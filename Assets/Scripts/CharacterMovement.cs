using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float Speed = 5f;

    public float RaycastLength = 0.1f;

    public float JumpForce = 2f;
    public int mask = 1 << 3;
    private Rigidbody _rb;
    public bool isGrounded = false;
    private int _runDir;
    // public Animator AnimControl;
    private Anim Anim;
    private void Awake() {
        _rb = GetComponent<Rigidbody>();
        // AnimControl = GetComponent<Animator>();
        Anim = GetComponent<Anim>();

    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(!isGrounded)
                CheckGround();
            if(isGrounded){
                _rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
                isGrounded = false;
                // AnimControl.SetBool("isJumping", true);
                Anim.Jump(true);
            }
        }
    }
    private void FixedUpdate() {
        Vector2 _targetVelocity = new Vector2(Input.GetAxis("Horizontal") * Speed, Input.GetAxis("Vertical") * Speed);
        if(isGrounded && _targetVelocity != Vector2.zero){
            _rb.velocity = transform.rotation * new Vector3(_targetVelocity.x, _rb.velocity.y, _targetVelocity.y);
            Anim.SetRunMode(_targetVelocity);
            // if(_rb.velocity.x > 0){
            //     AnimControl.SetBool("isRunning", true);
            // }
            // else{
            //     AnimControl.SetBool("isRunning", false);
            // }
        }
        else{
            Anim.SetRunMode(Vector3.zero, false);
            // AnimControl.SetBool("isRunning", false);
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
}
