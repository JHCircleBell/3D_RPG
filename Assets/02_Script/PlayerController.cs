using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Interactable focus;

    Camera cam;

    [SerializeField] private LayerMask movementMask;
    PlayerMotor motor;

    private void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // ��Ŭ�� �̵�
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, movementMask)) // ����, layermask
            {
                //Debug.Log("�ε��� ��� : " + hit.collider.name + " " + hit.point);
                motor.MoveToPoint(hit.point);
                // �̵��� ��Ͱ� �ε�������
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(0)) // ��Ŭ�� ��ȣ�ۿ�
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) // ����, layermask
            {
                // ��ȣ�ۿ� üũ
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    Debug.Log("��ȣ�ۿ� ����");
                    SetFocus(interactable);
                }
            }
        }
    }

    private void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDeFocused();
            }
            
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }

    private void RemoveFocus()
    {
        if(focus != null)
        {
            focus.OnDeFocused();
        }
        
        focus = null;
        motor.StopFollowTarget();
    }
}
