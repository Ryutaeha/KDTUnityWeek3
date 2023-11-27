using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class BtnManager : MonoBehaviour
{

    // 정적으로 접근 가능한 인스턴스
    private static BtnManager instance;

    // 다른 스크립트에서 BtnManager.Instance로 접근할 수 있도록 프로퍼티 제공
    public static BtnManager Instance
    {
        get
        {
            if (instance == null)
            {
                // 씬 내에서 찾아보고 없으면 새로 생성
                instance = FindObjectOfType<BtnManager>();

                if (instance == null)
                {
                    // BtnManager 오브젝트가 씬에 없으면 새로 생성
                    GameObject singletonObject = new GameObject("BtnManager");
                    instance = singletonObject.AddComponent<BtnManager>();
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

    
        void Start()
    {
        
    }


    void Update()
    {
        
    }
}
