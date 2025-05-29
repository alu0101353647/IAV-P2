using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : NPCBaseFSM
{
    float healthRecoverPerTick = 2f;
    float healthRecoverCD = 1f;
    float? healTimestamp;
    Health healthScript;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        agent.ResetPath();
        healthScript = animator.gameObject.GetComponent<Health>();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        HealOnCD();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }

    void HealOnCD()
    {
        if (healTimestamp == null) { healTimestamp = Time.time; }
        if (Time.time - healTimestamp >= healthRecoverCD)
        {
            healthScript.Damage(-healthRecoverPerTick);
            healTimestamp = Time.time;
        }
    }

}
