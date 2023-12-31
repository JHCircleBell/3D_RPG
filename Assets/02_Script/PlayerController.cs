using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


        if (Input.GetMouseButtonDown(1)) // 우클릭 이동
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, movementMask)) // 범위, layermask
            {
                //Debug.Log("부딛힌 대상 : " + hit.collider.name + " " + hit.point);
                motor.MoveToPoint(hit.point);
                // 이동과 어떤것과 부딛혔는지
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(0)) // 좌클릭 상호작용
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) // 범위, layermask
            {
                // 상호작용 체크
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    Debug.Log("상호작용 가능");
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
