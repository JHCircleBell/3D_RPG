using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharaterStats))]
public class CharaterCombat : MonoBehaviour
{
    [SerializeField] private float attackSpeed = 1f;
    private float attackCooldown = 0f;

    CharaterStats myStats;

    private void Start()
    {
        myStats = GetComponent<CharaterStats>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharaterStats targetStats)
    {
        if(attackCooldown <= 0f)
        {
            targetStats.TakeDamage(myStats.damage.GetValue());
            attackCooldown = 1f / attackSpeed;
        }
        
    }
}
