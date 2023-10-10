using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public float switchDelay = 1f;
    public GameObject[] weapon;

    private int index = 0;
    private bool isSwitching = false;

    private void Start()
    {
        InitializeWeapon();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && !isSwitching)
        {
            index++;
            if(index >= weapon.Length)
            {
                index = 0;
            }

            StartCoroutine(SwitchDelay(index));
        }

        if (Input.GetKeyDown(KeyCode.X) && !isSwitching)
        {
            index--;
            if (index < 0)
            {
                index = weapon.Length - 1;
                StartCoroutine(SwitchDelay(index));
            }
        }
    }
    // >> 
    // 01. ������������ ������ ���� ���Կ� ������ �ϰ������� ���⺯��(�����κ��丮�� ����)
    // 02. �κ��丮 ������ ����â���� (���� ��ư�� ���ؼ� �����)
    // 03. �����̺�Ʈ(Ŭ��) �߻��ϸ� 01 �� �Լ� ȣ��
    private void InitializeWeapon()
    {
        for (int i = 0; i < weapon.Length; i++)
        {
            weapon[i].SetActive(false);
        }
        weapon[0].SetActive(true);
        index = 0;
    }

    private IEnumerator SwitchDelay(int newIndex)
    {
        isSwitching = true;
        SwitchWeapons(newIndex);
        yield return new WaitForSeconds(switchDelay);
        isSwitching = false;
    }

    private void SwitchWeapons(int newIndex)
    {
        for (int i = 0; i < weapon.Length; i++)
        {
            weapon[i].SetActive(false);
        }
        weapon[newIndex].SetActive(true);
    }

}
