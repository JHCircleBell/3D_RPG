using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float lookRadius = 5f;

    Transform target;
    NavMeshAgent agent;
    CharaterCombat combat;

    private Animator anim;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharaterCombat>();
    }

    
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
                CharaterStats targetStats = target.GetComponent<CharaterStats>();
                if(targetStats != null)
                {
                    // 공격
                    anim.SetBool("Attack", true);

                    combat.Attack(targetStats);
                }
                
                // todo.. 타겟 마주보기
                FaceTarget();
            }
        }

        if(distance > lookRadius)
        {
            anim.SetBool("Attack", false);
        }
    }


    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotaion = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotaion, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
