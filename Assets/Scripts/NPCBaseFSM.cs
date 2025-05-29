using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour
{
    protected GameObject NPC;
    protected UnityEngine.AI.NavMeshAgent agent;
    protected GameObject opponent;
    public float speed = 2.0f;
    public float rotSpeed = 1.0f;
    public float accuracy = 3.0f;
    public float hitboxRadius = 1;
    Health health;

    //line of sight stuff
    public float visDist = 20.0f;
    float visAngle = 60.0f;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        opponent = GameObject.FindGameObjectWithTag("Player");
        agent = NPC.GetComponent<UnityEngine.AI.NavMeshAgent>();
        health = NPC.GetComponent<Health>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        animator.SetBool("playerSpotted", CanSeePlayer());
        animator.SetFloat("health", CheckHits());
        animator.SetFloat("distance", PlayerDistance());
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //agent.ResetPath();
    }

    private float PlayerDistance()
    {
        return Vector3.Distance(NPC.gameObject.transform.position, opponent.gameObject.transform.position);
    }

    private float CheckHits()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullet");
        for (int i = 0; i < bullets.Length; ++i)
        {
            if (Vector3.Distance(bullets[i].transform.position, NPC.transform.position) < hitboxRadius)
            {
                Bullet script = bullets[i].GetComponent<Bullet>();
                health.Damage(script.damage);
                Destroy(bullets[i]);
            }
        }
        return health.current;
    }

    private bool CanSeePlayer()
    {
        Vector3 direction = opponent.transform.position - NPC.transform.position;
        float angle = Vector3.Angle(direction, NPC.transform.forward);

        return direction.magnitude < visDist && angle < visAngle;
    }
    protected void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

}
