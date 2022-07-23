using System;
using UnityEngine;

public class Anim : MonoBehaviour
{
    private Animator _animControl;
    private CharacterMovement _move;
    private void Awake() {
        _animControl = GetComponent<Animator>();
        _move = GetComponent<CharacterMovement>();
    }
    internal void Jump(bool val) => _animControl.SetBool("isJumping", val);

    internal void SetRunMode(Vector2 _velo, bool _value = true){
        RunModes mode;
        if(_value == false){
            mode = RunModes.Stay;
        } 
        else if(Math.Abs(_velo.y) > Math.Abs(_velo.x)){
            mode = _velo.y > 0 ? RunModes.Forward : RunModes.Backward;
        }
        else{
            if(_velo.y < 0) mode = _velo.x > 0 ? RunModes.BackwardRight : RunModes.BackwardLeft;
            else mode = _velo.x > 0 ? RunModes.Right : RunModes.Left;
        }
        _animControl.SetInteger("RunMode", (int)mode);
    }

    enum RunModes
    {
        Stay,
        Forward,
        Right,
        BackwardRight,
        Backward,
        BackwardLeft,
        Left
    }

}
