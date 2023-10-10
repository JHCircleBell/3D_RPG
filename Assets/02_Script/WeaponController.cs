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
    // 01. 장착아이템이 있으면 같은 슬롯에 장착을 하고있으면 무기변경(기존인벤토리로 복구)
    // 02. 인벤토리 아이템 선택창에서 (장착 버튼을 통해서 만들기)
    // 03. 장착이벤트(클릭) 발생하면 01 번 함수 호출
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
