using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropItem : MonoBehaviour
{
    private Vector3 pos;
    [SerializeField] private GameObject[] items;

    private void OnDestroy()
    {
        pos = new Vector3(0f, 2f, 1f);
        transform.position = gameObject.transform.position + pos;
        StartCoroutine("dropItem");
    }


    
    IEnumerator dropItem()
    {
        int maxItem = 10;
        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i < maxItem; i++)
        {
            int rand = Random.Range(0, 3);

            yield return new WaitForSeconds(0.3f);
            Instantiate(items[rand], transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }

    private void AddHP()
    {
        // HP증가

    }

    private void AddMP()
    {
        // MP증가

    }


}
