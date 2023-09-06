using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    private Vector3 dir; // 이동 방향
    private Vector3 targetPos; // 목표 위치

    private CharacterController characterController; // 캐릭터 컨트롤러
    private Camera mainCamera;

    private Animator anim;
    private static int Walk = Animator.StringToHash("Walk");
    private static int Run = Animator.StringToHash("Run");
    private static int Die = Animator.StringToHash("Die");
    private static int Attack = Animator.StringToHash("Attack"); // 우선 일반공격

    private Rigidbody rb;

    private void Awake()
    {
        mainCamera = Camera.main;

        rb = GetComponent<Rigidbody>();

        if (!TryGetComponent<CharacterController>(out characterController))
        {
            Debug.Log("CharController.cs - Awake() - characterController 참조 실패");
        }

        InitCharController();

    }

    private void InitCharController()
    {
        if(!TryGetComponent<Animator>(out anim))
        {
            Debug.Log("CharController.cs - Awake() - anim 참조 실패");
        }
    }


    private void Update()
    {
        // 01. 키보드로 캐릭터 이동
        //move.x = Input.GetAxisRaw("Horizontal");
        //move.z = Input.GetAxisRaw("Vertical");
        //move.Normalize();

        //transform.position += (moveSpeed * Time.deltaTime * move);
        //transform.LookAt(transform.position + move);



        // 02. 마우스로 캐릭터 이동
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                targetPos = raycastHit.point;
                gameObject.transform.LookAt(targetPos);
                
            }
        }
        if(Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            Move();
        }

        

        if (Input.GetKeyDown(KeyCode.Q) && !isDashing)
        {
            //anim.SetTrigger(Attack);
            
            StartCoroutine("DashAttack");
            
            
        }

        //if (Input.GetKeyDown(KeyCode.LeftShift)) // todo.. Run에대한 Animation 다시 찾아오기
        //{
        //    anim.SetTrigger(animParam_Run);
        //}

    }

    private bool isDashing = false;    
    [SerializeField] private float dashDistance;
    [SerializeField] private float dashSpeed;
    private IEnumerator DashAttack()
    {

        isDashing = true;

        anim.SetTrigger("Attack");
        

        Vector3 dashStartPosition = transform.position; // 현위치
        Vector3 dashEndPosition = transform.position + transform.forward * dashDistance; // 현위치 + 앞으로 이동거리 + 대쉬 거리


        float startTime = Time.time; // 시작시간이 현재 시간
        float journeyLength = Vector3.Distance(dashStartPosition, dashEndPosition); // 시작위치랑 엔드포지션의 우치의 차이

        while (Time.time < startTime + journeyLength / dashSpeed) 
        {
            float distanceCovered = (Time.time - startTime) * dashSpeed * Time.deltaTime;
            float fractionOfJourney = distanceCovered / journeyLength;
            characterController.Move(Vector3.Lerp(dashStartPosition, dashEndPosition, fractionOfJourney));
            
            yield return null;
        }

        Debug.Log(dashStartPosition + "  " + dashEndPosition);

        isDashing = false;
    }



    private void Move() // 이동 관련 함수
    {
        Vector3 thisUpdatePoint = (targetPos - transform.position).normalized * moveSpeed;
        characterController.SimpleMove(thisUpdatePoint);
    }

    // 참고 코드 : https://stickode.tistory.com/309
}
