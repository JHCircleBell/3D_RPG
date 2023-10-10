using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    Equipment[] currentEquipment;

    // callback
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;

        int slotNum = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[slotNum];
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            // currentEquipment[slotIndex].isEquiped = true;
            inventory.Add(oldItem);
        }

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip(int slotIndex)
    {
        if(currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            // currentEquipment[slotIndex].isEquiped = false;
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
}


// 무기 교체에 대한 내용 참고 : https://heyzlluck.tistory.com/entry/%EC%9C%A0%EB%8B%88%ED%8B%B0-%EB%AC%B4%EA%B8%B0-%EB%B0%94%EA%BE%B8%EA%B8%B0-%EB%AC%B4%EA%B8%B0-%EA%B5%90%EC%B2%B4-%EA%BF%80%ED%8C%81

// 무기 장착 내용 참고 : https://m.blog.naver.com/gold_metal/220526236275
