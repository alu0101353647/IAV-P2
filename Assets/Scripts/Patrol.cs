using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Patrol : NPCBaseFSM
{
    Vector3 wanderTarget = Vector3.zero;
    public float wanderRadius = 2f;
    public float wanderDistance = 8f;
    public float wanderJitter = 0.2f;
    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        Wander();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }

    void Wander()
    {
        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
                                0,
                                Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;
        Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);
        Vector3 targetWorld = NPC.transform.position + NPC.gameObject.transform.TransformVector(targetLocal);


        Seek(targetWorld);
    }
}
