//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CharController_x : MonoBehaviour
//{
//    [SerializeField]
//    private float moveSpeed = 5f;
//    private Vector3 dir; // �̵� ����
//    private Vector3 targetPos; // ��ǥ ��ġ

//    private CharacterController characterController; // ĳ���� ��Ʈ�ѷ�
//    private Camera mainCamera;

//    private Animator anim;
//    private static int Walk = Animator.StringToHash("Walk");
//    private static int Run = Animator.StringToHash("Run");
//    private static int Die = Animator.StringToHash("Die");
//    private static int Attack = Animator.StringToHash("Attack"); // �켱 �Ϲݰ���

//    private bool isRunning = false;

//    private void Awake()
//    {
//        characterController = GetComponent<CharacterController>();
//        anim = GetComponent<Animator>();
        

//        if (!TryGetComponent<CharacterController>(out characterController))
//        {
//            Debug.Log("CharController.cs - Awake() - characterController ���� ����");
//        }

//        InitCharController();

//    }

//    private void InitCharController()
//    {
//        if(!TryGetComponent<Animator>(out anim))
//        {
//            Debug.Log("CharController.cs - Awake() - anim ���� ����");
//        }
        
//    }


//    private void Update()
//    {
//        // 01. Ű����� ĳ���� �̵�
//        //move.x = Input.GetAxisRaw("Horizontal");
//        //move.z = Input.GetAxisRaw("Vertical");
//        //move.Normalize();

//        //transform.position += (moveSpeed * Time.deltaTime * move);
//        //transform.LookAt(transform.position + move);

//        // 02. ���콺�� ĳ���� �̵�
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

//            // �ִϸ��̼��� ����Ǹ� ���°��� ��������ִµ� ������ �ȵǴ� ������ ����
//            //if (false == anim.IsInTransition(0))
//            //{
//            //    anim.SetBool("Run", false);
//            //    //anim.SetBool("Walk", true);
//            //}
//        }

        

        
//        // 03. Q�� ���� �� Attack �ִϸ��̼� ����
//        if (Input.GetKeyDown(KeyCode.Q))
//        {
//            anim.SetTrigger(Attack);

//            StartCoroutine(DashAttack());
//        }
        
        
        

//        //if (Input.GetKeyDown(KeyCode.LeftShift)) // todo.. Run������ Animation �ٽ� ã�ƿ���
//        //{
//        //    anim.SetTrigger(animParam_Run);
//        //}

//    }




//    #region �뽬���� ����
//    private bool isDashing = false;
//    [SerializeField] private float dashDistance = 5f;
//    [SerializeField] private float dashSpeed = 10f;

    

//    private IEnumerator DashAttack()
//    {

//        isDashing = true;

//        anim.SetTrigger("Attack");


//        Vector3 dashStartPosition = transform.position; // ����ġ
//        Vector3 dashEndPosition = transform.position + new Vector3(0f, 0f, 0f) * dashDistance; // ����ġ + ������ �̵��Ÿ� + �뽬 �Ÿ�


//        float startTime = Time.time; // ���۽ð��� ���� �ð�
//        float journeyLength = Vector3.Distance(dashEndPosition, dashStartPosition); // ������ġ�� ������������ ��ġ�� ����

//        while (Time.time < startTime + journeyLength / dashSpeed) // ����ð� < ���۽ð� + �̵��Ÿ�/�뽬�ӵ�
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

//    private void Move() // �̵� ���� �Լ�
//    {
//        Vector3 thisUpdatePoint = (targetPos - transform.position).normalized * moveSpeed;
//        characterController.SimpleMove(thisUpdatePoint);

//        //anim.SetBool("Walk", true);
//    }

    

//    // ���� �ڵ� : https://stickode.tistory.com/309
//    // https://stickode.tistory.com/360
//}
