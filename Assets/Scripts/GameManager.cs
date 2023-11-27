using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤 인스턴스를 저장할 정적 변수
    private static GameManager instance;

    // 다른 스크립트에서 접근할 수 있는 속성
    public static GameManager Instance
    {
        get
        {
            // 인스턴스가 없을 경우 생성
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                // 게임 내에 GameManager가 없는 경우 새로운 오브젝트에 추가
                if (instance == null)
                {
                    GameObject singleton = new GameObject("GameManager");
                    instance = singleton.AddComponent<GameManager>();
                }
            }

            return instance;
        }
    }

    // 게임매니저의 기능이나 상태에 대한 메서드들을 추가할 수 있음

    // 예시 메서드
    public void StartGame()
    {
        Debug.Log("Game Started!");
    }

    public void EndGame()
    {
        Debug.Log("Game Ended!");
    }

    private void Awake()
    {
        // 씬 전환 시 인스턴스가 유지되도록 설정
        DontDestroyOnLoad(gameObject);

        // 이미 인스턴스가 존재하는 경우 중복 생성 방지
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
