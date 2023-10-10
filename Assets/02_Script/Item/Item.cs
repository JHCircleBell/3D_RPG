using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    // ��巹���� ����/��ũ���ͺ� ������Ʈ �����ϱ�


    new public string itemName = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public bool isEquiped = false; // isEquiped false�� �ֵ鸸 �κ��丮���� ����������

    public virtual void Use()
    {
        Debug.Log("������� ������ :" + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}

