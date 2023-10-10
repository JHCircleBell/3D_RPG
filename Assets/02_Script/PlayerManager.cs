using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject player;

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // 여기서 빌드 세팅으로 초기화 됨.
        // 추후에 캐릭터 사망시 어떤식으로 진행해야 할 지 고민해봐야함
    }
}
