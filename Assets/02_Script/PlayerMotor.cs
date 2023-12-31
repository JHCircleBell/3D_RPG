using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMotor : MonoBehaviour
{
    Transform target;

    NavMeshAgent agent;
    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        //GetInput();
        //Interation();
        if(target != null)
        {
            agent.SetDestination(target.position);
            FaceToTarget();
        }

    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point); // 목표 위치로 이동
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * 0.8f;
        agent.updateRotation = false;

        target = newTarget.interactionTransform;
        
    }

    public void StopFollowTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;

        target = null;
    }

    private void FaceToTarget()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x,0f,dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }



    //private GameObject nearWeapon;
    //[SerializeField] private GameObject[] weapons;
    //[SerializeField] private bool[] hasWeapons;
    //private bool isDown;

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Weapon"))
    //    {
    //        nearWeapon = other.gameObject;
    //        Debug.Log(nearWeapon.name);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Weapon"))
    //    {
    //        nearWeapon = null;
    //    }
    //}

    //private void GetInput()
    //{
    //    isDown = Input.GetButtonDown("Interaction");
    //}

    //private void Interation()
    //{
    //    if(isDown && nearWeapon != null)
    //    {
    //        if (nearWeapon.CompareTag("Weapon"))
    //        {
    //            Item item = nearWeapon.GetComponent<Item>();
    //            int weaponIndex = item.Value;
    //            hasWeapons[weaponIndex] = true;

    //            Destroy(nearWeapon);
    //        }
    //    }
    //}
}
