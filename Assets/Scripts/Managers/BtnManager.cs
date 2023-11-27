using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class BtnManager : MonoBehaviour
{

    // �������� ���� ������ �ν��Ͻ�
    private static BtnManager instance;

    // �ٸ� ��ũ��Ʈ���� BtnManager.Instance�� ������ �� �ֵ��� ������Ƽ ����
    public static BtnManager Instance
    {
        get
        {
            if (instance == null)
            {
                // �� ������ ã�ƺ��� ������ ���� ����
                instance = FindObjectOfType<BtnManager>();

                if (instance == null)
                {
                    // BtnManager ������Ʈ�� ���� ������ ���� ����
                    GameObject singletonObject = new GameObject("BtnManager");
                    instance = singletonObject.AddComponent<BtnManager>();
                }
            }

            return instance;
        }

    }
    private void Awake()
    {
        // �� ��ȯ �� �ν��Ͻ��� �����ǵ��� ����
        DontDestroyOnLoad(gameObject);

        // �̹� �ν��Ͻ��� �����ϴ� ��� �ߺ� ���� ����
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
