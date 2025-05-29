using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : NPCBaseFSM
{
    float? shootTimestamp;
    float shootCD = 0.5f;
    [SerializeField] GameObject bulletPrefab;
    Transform bulletSpawnPos;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        bulletSpawnPos = GameObject.Find("BulletSpawn").transform;
        agent.ResetPath();//stop
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        NPC.transform.LookAt(opponent.transform);
        ShootOnCD();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }

    void ShootOnCD()
    {
        if (shootTimestamp == null) { shootTimestamp = Time.time; }
        if (Time.time - shootTimestamp >= shootCD)
        {
            Instantiate(bulletPrefab, bulletSpawnPos.position, bulletSpawnPos.rotation);
            shootTimestamp = Time.time;
        }
    }
}
