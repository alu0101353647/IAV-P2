using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Hide : NPCBaseFSM
{
    Vector3 chosenSpot = Vector3.zero;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        MoveToHidingSpot();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if (Vector3.Distance(animator.gameObject.transform.position, chosenSpot) < 4)
        {
            animator.SetBool("hidden", true);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }

    void MoveToHidingSpot()
    {
        float dist = Mathf.Infinity;
        for (int i = 0; i < World.Instance.GetHidingSpots().Length; i++)
        {
            Vector3 hideDir = World.Instance.GetHidingSpots()[i].transform.position - opponent.transform.position;
            Vector3 hidePos = World.Instance.GetHidingSpots()[i].transform.position + hideDir.normalized * 10;

            if (Vector3.Distance(NPC.transform.position, hidePos) < dist)
            {
                chosenSpot = hidePos;
                dist = Vector3.Distance(NPC.transform.position, hidePos);
            }
        }
        Seek(chosenSpot);
    }

}
