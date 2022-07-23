using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackBeh : StateMachineBehaviour
{
    Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        float _distance = Vector3.Distance(animator.transform.position, player.position);
        Debug.DrawLine(animator.transform.position, player.position, Color.blue);
        if(_distance > 3f)
            animator.SetBool("isAttacking", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
