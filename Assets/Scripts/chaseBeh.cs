using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chaseBeh : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    private float _attackRange = 1f;
    private float _chaseRange = 10f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 4f;
        agent.SetDestination(player.position);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float _distance = Vector3.Distance(animator.transform.position, player.position);
        if(_distance < _attackRange){
            animator.SetBool("isAttacking", true);
        }
        if(_distance > _chaseRange)
            animator.SetBool("isChasing", false);
        agent.SetDestination(player.position);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        agent.speed = 2f;
    }

}
