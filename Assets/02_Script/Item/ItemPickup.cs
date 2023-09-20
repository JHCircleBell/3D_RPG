using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Pick up " + item.name);
        bool isPickUp = Inventory.instance.Add(item);

        if (isPickUp)
        {
            Destroy(gameObject);
        }
        
    }

    //private void Update()
    //{
    //    transform.Rotate(Vector3.up * 10 * Time.deltaTime);
    //}
}
