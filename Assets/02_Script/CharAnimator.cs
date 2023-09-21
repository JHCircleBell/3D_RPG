using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharAnimator : MonoBehaviour
{
    private NavMeshAgent agent;

    // agent x,z 랑 traget 의 x,z 값만 비교
    
    private Animator anim;
    private static int Walk = Animator.StringToHash("Walk");
    private static int Run = Animator.StringToHash("Run");
    private static int Die = Animator.StringToHash("Die");
    private static int Attack = Animator.StringToHash("Attack");

    [SerializeField] private float moveSpeed = 3f;
    private Vector3 move = Vector3.zero;

    private Vector3 target;
    private Vector3 me;
    //private Vector3 


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        target = agent.transform.position;
    }

    private void Update()
    {

        me = agent.transform.position;
        me.y = 0f;
        target.y = 0f;
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                target = raycastHit.point;
                agent.transform.LookAt(target);
            }
        }

        if (Vector3.Distance(me, target) > 0.1f)
        {
            // anim.speed = 1f;
            anim.SetBool("Walk", true);

            // Debug.Log(Vector3.Distance(agent.transform.position, target));

            // 
        }

        if (Vector3.Distance(me, target) <= 0.1f)
        {
            // 애니메이션 재생속도 조절하기
            // https://www.youtube.com/watch?v=rEtFhF-B-94 참고
            // anim.speed = 0.1f;
            anim.SetBool("Walk", false);
        }

    }
}
