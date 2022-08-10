using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBeh : MonoBehaviour
{
    Transform player;
    Animator anim;
    NavMeshAgent agent;
    List<Vector3> points;
    private State state;
    private Vector3 pointBuf;
    private bool coroutineActive;

    private void Awake() {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        points = new List<Vector3>();
        for (int index = 2; index < transform.childCount; index++){
            points.Add(transform.GetChild(index).position);
        }
    }
    private void Start() {
        StartPatrol();
    }

    private void FixedUpdate() {
        if(state == State.isPatroling){
            if(agent.remainingDistance <= agent.stoppingDistance){
                points.Add(pointBuf);
                pointBuf = points[Random.Range(0, points.Count-1)];
                agent.SetDestination(pointBuf);
                points.Remove(pointBuf);
            }
        }

        if(state == State.isChasing){
            if(coroutineActive == false){
                if(agent.remainingDistance < 2f){
                    Attack();
                    return;
                }
                agent.SetDestination(player.position);
                coroutineActive = true;
                StartCoroutine("Chasing");
            }
        }
        
        if(state == State.isAttacking){
            if(!coroutineActive){
                transform.LookAt(player.position);
                coroutineActive = true;
                StartCoroutine("Turning");
            }
        
        }


    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == 7){
            agent.SetDestination(other.transform.position);
            agent.speed = 4f;
            state = State.isChasing;
            SetState("isChasing");
            player = other.transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.layer == 7){
            agent.speed = 2f;
            StartPatrol();
        }
    }

    private void StartPatrol(){
        pointBuf = points[Random.Range(0, points.Count)];
        agent.SetDestination(pointBuf);
        points.Remove(pointBuf);
        state = State.isPatroling;
        SetState("isPatroling");
    }

    private void Attack(){
        SetState("isAttacking");
        state = State.isAttacking;
    }

    private void SetState(string state){
        foreach(AnimatorControllerParameter param in anim.parameters){
            anim.SetBool(param.name, false);
        }
        anim.SetBool(state, true);
        
    }
    private IEnumerator Chasing(){
        coroutineActive = false;
        yield return new WaitForSeconds(0.1f);
    }
    private IEnumerator Turning(){
        coroutineActive = false;
        yield return new WaitForSeconds(0.1f);

    }
    enum State
    {
        isPatroling,
        isChasing,
        isAttacking
    }
}
