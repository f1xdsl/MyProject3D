using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleBeh : StateMachineBehaviour
{
    float timer;
    private Transform player;
    private float _chaseRange = 10f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

 
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if(timer > 5)
            animator.SetBool("isPatrolling", true);
        


        float _distance = Vector3.Distance(animator.transform.position, player.position);

        if(_distance < _chaseRange)
            animator.SetBool("isChasing", true);

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }


}
