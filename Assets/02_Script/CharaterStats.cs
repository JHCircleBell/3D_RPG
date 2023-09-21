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
        Debug.Log(gameObject.name + "�� " + damage + "��ŭ�� �������� �Ծ����ϴ�.");

        if(currentHP <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(gameObject.name + "���");

        // todo.. ��� �ִϸ��̼� ó�� �ؾߵ�
    }
}
