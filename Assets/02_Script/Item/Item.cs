using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    // 어드레서블 에셋/스크립터블 오브젝트 공부하기


    new public string itemName = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public bool isEquiped = false; // isEquiped false인 애들만 인벤토리에서 보여지도록

    public virtual void Use()
    {
        Debug.Log("사용중인 아이템 :" + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}

