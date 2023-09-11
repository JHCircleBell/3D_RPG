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
        myMaterial = GetComponent<MeshRenderer>().material; // Damage를 받으면 메테리얼 변경
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Projectile")))
        {

        }
    }
}
