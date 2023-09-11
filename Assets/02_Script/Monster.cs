using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private int maxHP;
    [SerializeField] private int curHP;
    Material myMaterial;

    private void Awake()
    {
        myMaterial = GetComponent<MeshRenderer>().material; // Damage�� ������ ���׸��� ����
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Projectile")))
        {

        }
    }
}
