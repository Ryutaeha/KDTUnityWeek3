using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public TMP_Text playerName;

    // 다른 스크립트에서 접근할 수 있는 속성
    public static Player Instance
    {
        get
        {
            // 인스턴스가 없을 경우 생성
            if (instance == null)
            {
                instance = FindObjectOfType<Player>();

                // 게임 내에 Player가 없는 경우 새로운 오브젝트에 추가
                if (instance == null)
                {
                    GameObject singleton = new GameObject("Player");
                    instance = singleton.AddComponent<Player>();
                }
            }

            return instance;
        }
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

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Movement>().MoveSet(false);
        transform.GetComponent<AimRotation>().AimSet(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
