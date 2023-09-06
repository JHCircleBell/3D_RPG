using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    private Vector3 dir; // �̵� ����
    private Vector3 targetPos; // ��ǥ ��ġ

    private CharacterController characterController; // ĳ���� ��Ʈ�ѷ�
    private Camera mainCamera;

    private Animator anim;
    private static int Walk = Animator.StringToHash("Walk");
    private static int Run = Animator.StringToHash("Run");
    private static int Die = Animator.StringToHash("Die");
    private static int Attack = Animator.StringToHash("Attack"); // �켱 �Ϲݰ���

    private Rigidbody rb;

    private void Awake()
    {
        mainCamera = Camera.main;

        rb = GetComponent<Rigidbody>();

        if (!TryGetComponent<CharacterController>(out characterController))
        {
            Debug.Log("CharController.cs - Awake() - characterController ���� ����");
        }

        InitCharController();

    }

    private void InitCharController()
    {
        if(!TryGetComponent<Animator>(out anim))
        {
            Debug.Log("CharController.cs - Awake() - anim ���� ����");
        }
    }


    private void Update()
    {
        // 01. Ű����� ĳ���� �̵�
        //move.x = Input.GetAxisRaw("Horizontal");
        //move.z = Input.GetAxisRaw("Vertical");
        //move.Normalize();

        //transform.position += (moveSpeed * Time.deltaTime * move);
        //transform.LookAt(transform.position + move);



        // 02. ���콺�� ĳ���� �̵�
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

        //if (Input.GetKeyDown(KeyCode.LeftShift)) // todo.. Run������ Animation �ٽ� ã�ƿ���
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
        

        Vector3 dashStartPosition = transform.position; // ����ġ
        Vector3 dashEndPosition = transform.position + transform.forward * dashDistance; // ����ġ + ������ �̵��Ÿ� + �뽬 �Ÿ�


        float startTime = Time.time; // ���۽ð��� ���� �ð�
        float journeyLength = Vector3.Distance(dashStartPosition, dashEndPosition); // ������ġ�� ������������ ��ġ�� ����

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



    private void Move() // �̵� ���� �Լ�
    {
        Vector3 thisUpdatePoint = (targetPos - transform.position).normalized * moveSpeed;
        characterController.SimpleMove(thisUpdatePoint);
    }

    // ���� �ڵ� : https://stickode.tistory.com/309
}
