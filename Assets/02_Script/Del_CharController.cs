//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CharController_x : MonoBehaviour
//{
//    [SerializeField]
//    private float moveSpeed = 5f;
//    private Vector3 dir; // 이동 방향
//    private Vector3 targetPos; // 목표 위치

//    private CharacterController characterController; // 캐릭터 컨트롤러
//    private Camera mainCamera;

//    private Animator anim;
//    private static int Walk = Animator.StringToHash("Walk");
//    private static int Run = Animator.StringToHash("Run");
//    private static int Die = Animator.StringToHash("Die");
//    private static int Attack = Animator.StringToHash("Attack"); // 우선 일반공격

//    private bool isRunning = false;

//    private void Awake()
//    {
//        characterController = GetComponent<CharacterController>();
//        anim = GetComponent<Animator>();
        

//        if (!TryGetComponent<CharacterController>(out characterController))
//        {
//            Debug.Log("CharController.cs - Awake() - characterController 참조 실패");
//        }

//        InitCharController();

//    }

//    private void InitCharController()
//    {
//        if(!TryGetComponent<Animator>(out anim))
//        {
//            Debug.Log("CharController.cs - Awake() - anim 참조 실패");
//        }
        
//    }


//    private void Update()
//    {
//        // 01. 키보드로 캐릭터 이동
//        //move.x = Input.GetAxisRaw("Horizontal");
//        //move.z = Input.GetAxisRaw("Vertical");
//        //move.Normalize();

//        //transform.position += (moveSpeed * Time.deltaTime * move);
//        //transform.LookAt(transform.position + move);

//        // 02. 마우스로 캐릭터 이동
//        if (Input.GetMouseButtonDown(1))
//        {
//            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//            if (Physics.Raycast(ray, out RaycastHit raycastHit))
//            {
//                targetPos = raycastHit.point;
//                gameObject.transform.LookAt(targetPos);
                
//            }
//        }



//        if(Vector3.Distance(transform.position, targetPos) > 0.1f)
//        {
//            Move();
//            anim.SetBool("Walk", true);

//            // 
//        }
//        else if (Vector3.Distance(transform.position, targetPos) <= 0.1f)
//        {
//            anim.SetBool("Walk", false);
//        }


//        if (Input.GetKeyDown(KeyCode.LeftShift))
//        {
//            anim.SetBool("Run", true);

//            // 애니메이션이 종료되면 상태값을 변경시켜주는데 적용이 안되는 문제가 있음
//            //if (false == anim.IsInTransition(0))
//            //{
//            //    anim.SetBool("Run", false);
//            //    //anim.SetBool("Walk", true);
//            //}
//        }

        

        
//        // 03. Q를 누를 때 Attack 애니메이션 실행
//        if (Input.GetKeyDown(KeyCode.Q))
//        {
//            anim.SetTrigger(Attack);

//            StartCoroutine(DashAttack());
//        }
        
        
        

//        //if (Input.GetKeyDown(KeyCode.LeftShift)) // todo.. Run에대한 Animation 다시 찾아오기
//        //{
//        //    anim.SetTrigger(animParam_Run);
//        //}

//    }




//    #region 대쉬공격 구현
//    private bool isDashing = false;
//    [SerializeField] private float dashDistance = 5f;
//    [SerializeField] private float dashSpeed = 10f;

    

//    private IEnumerator DashAttack()
//    {

//        isDashing = true;

//        anim.SetTrigger("Attack");


//        Vector3 dashStartPosition = transform.position; // 현위치
//        Vector3 dashEndPosition = transform.position + new Vector3(0f, 0f, 0f) * dashDistance; // 현위치 + 앞으로 이동거리 + 대쉬 거리


//        float startTime = Time.time; // 시작시간이 현재 시간
//        float journeyLength = Vector3.Distance(dashEndPosition, dashStartPosition); // 시작위치랑 엔드포지션의 위치의 차이

//        while (Time.time < startTime + journeyLength / dashSpeed) // 현재시간 < 시작시간 + 이동거리/대쉬속도
//        {
//            float distanceCovered = (Time.time - startTime) * dashSpeed;
//            float fractionOfJourney = distanceCovered / journeyLength;
//            characterController.Move(Vector3.Lerp(dashStartPosition, dashEndPosition, fractionOfJourney));

//            yield return null;
//        }

//        Debug.Log(dashStartPosition + "  " + dashEndPosition);

//        isDashing = false;
//    }

//    #endregion

//    private void Move() // 이동 관련 함수
//    {
//        Vector3 thisUpdatePoint = (targetPos - transform.position).normalized * moveSpeed;
//        characterController.SimpleMove(thisUpdatePoint);

//        //anim.SetBool("Walk", true);
//    }

    

//    // 참고 코드 : https://stickode.tistory.com/309
//    // https://stickode.tistory.com/360
//}
