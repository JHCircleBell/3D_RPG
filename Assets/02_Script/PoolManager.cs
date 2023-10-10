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

        // ������ Ǯ�� ����ִ�(��Ȱ��ȭ��) ���ӿ�����Ʈ�� ����
            // �߰��ϸ� select ������ �Ҵ�
        foreach(GameObject item in pools[index])
        {
            if (!item.activeSelf) // ��Ȱ��ȭ �Ǿ�������
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // �� ã���� ���Ӱ� �����Ͽ� select ������ �Ҵ�
        if(select == null)
        {
            // �߰��ϸ� select ������ �Ҵ�
            select = Instantiate(prefabs[index], transform); // �θ� ������ ���ӿ�����Ʈ ����
            pools[index].Add(select);
        }

        return select;
    }
    public void Clear()
    {

    }
}
