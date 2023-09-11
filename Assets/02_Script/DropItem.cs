using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropItem : MonoBehaviour
{
    [SerializeField]
    private int itemCount;



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            itemCount++;
            gameObject.SetActive(false);
        }
    }

    private void AddHP()
    {
        // HP����

    }

    private void AddMP()
    {
        // MP����

    }


}
