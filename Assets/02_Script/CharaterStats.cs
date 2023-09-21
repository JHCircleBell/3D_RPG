using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterStats : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP { get; private set; }

    public Stat damage;
    public Stat armor;
    // public Stat 

    private void Awake()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHP -= damage;
        Debug.Log(gameObject.name + "가 " + damage + "만큼의 데미지를 입었습니다.");

        if(currentHP <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(gameObject.name + "사망");

        // todo.. 사망 애니메이션 처리 해야됨
    }
}
