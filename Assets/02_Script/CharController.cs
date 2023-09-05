using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    private Vector3 move;
    private Vector3 dir;

    private CharacterController characterController; // 캐릭터 컨트롤러
    private Camera mainCamera;

    private Animator anim;
    private static int animParam_Move = Animator.StringToHash("Player_Move");
    private static int animParam_Run = Animator.StringToHash("Player_Run");
    private static int animParam_Die = Animator.StringToHash("Player_Die");
    private static int animParam_Attack01 = Animator.StringToHash("Player_SwordAttack01"); // 우선 일반공격



    private void Awake()
    {
        mainCamera = Camera.main;
        //if (!TryGetComponent<Camera>(out mainCamera))
        //{
        //    Debug.Log("CharController.cs - Awake() - mainCamera 참조 실패");
        //}
        
        if(!TryGetComponent<CharacterController>(out characterController))
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

            if (Physics.Raycast(ray, out RaycastHit raycastHit, 100f))
            {
                move = raycastHit.point;

                Debug.Log("이동 위치 : " + move.ToString());
            }
        }

        //if (Vector3.Distance(transform.position, move) > 0.1f)
        //{
        //    Move();
        //}


        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger(animParam_Attack01);
        }

        //if (Input.GetKeyDown(KeyCode.LeftShift)) // todo.. Run에대한 Animation 다시 찾아오기
        //{
        //    anim.SetTrigger(animParam_Run);
        //}

    }
    private void Move()
    {
        
        transform.position = (move - transform.position).normalized * moveSpeed;
        
            
        characterController.SimpleMove(transform.position);
    }

    // 참고 코드 : https://stickode.tistory.com/309
}
