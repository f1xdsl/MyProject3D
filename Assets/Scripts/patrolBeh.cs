using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public class patrolBeh : StateMachineBehaviour
{

    private NavMeshAgent agent;
    private GameObject[] points;
    private Transform[] pointsT;
    private Transform player;
    private float _chaseRange = 10f;
    private float timer;
    private int _targetPoint = 0;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        points = GameObject.FindGameObjectsWithTag("Points");
        pointsT = Array.ConvertAll(points, new Converter<GameObject, Transform>(objToTransform));

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(pointsT[_targetPoint].position);
        Debug.Log(points.Length);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        System.Random rnd = new System.Random();

        if(agent.remainingDistance <= agent.stoppingDistance){
            int[] option = { -1, 1 };
            int _nextPoint = _targetPoint + option[rnd.Next(2)];
            _targetPoint = (_nextPoint) >= 0 ? _nextPoint % points.Length : (points.Length + _nextPoint);
            // _targetPoint = (_targetPoint + option[rnd.Next(2)]) % points.Length;
            Debug.Log(0%points.Length);
            agent.SetDestination(pointsT[_targetPoint].position);
        }

        timer += Time.deltaTime;
        if(timer > 10){
            animator.SetBool("isPatrolling", false);
        }
        
        float _distance = Vector3.Distance(animator.transform.position, player.position);
        if(_distance < _chaseRange){
            animator.SetBool("isChasing", true);
            animator.SetBool("isPatrolling", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.gameObject.transform.position);
    }

    private Transform objToTransform(GameObject obj){
        return obj.transform;
    }

    
}
