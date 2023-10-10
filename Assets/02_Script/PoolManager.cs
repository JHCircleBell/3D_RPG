using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
   
    [SerializeField] private GameObject[] prefabs;

   
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; ++i)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // 선택한 풀에 놀고있는(비활성화된) 게임오브젝트에 접근
            // 발견하면 select 변수에 할당
        foreach(GameObject item in pools[index])
        {
            if (!item.activeSelf) // 비활성화 되어있으면
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // 못 찾으면 새롭게 생성하여 select 변수에 할당
        if(select == null)
        {
            // 발견하면 select 변수에 할당
            select = Instantiate(prefabs[index], transform); // 부모 하위로 게임오브젝트 생성
            pools[index].Add(select);
        }

        return select;
    }
    public void Clear()
    {

    }
}
