using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow;
    [SerializeField]
    private Transform StartArrowPos;
    [SerializeField]
    private int Damage;
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private GameObject Target;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Monster")))
        {
            Debug.Log("Hit");
        }
    }
}
