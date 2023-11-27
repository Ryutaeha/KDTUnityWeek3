using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public TMP_Text playerName;

    // �ٸ� ��ũ��Ʈ���� ������ �� �ִ� �Ӽ�
    public static Player Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ��� ����
            if (instance == null)
            {
                instance = FindObjectOfType<Player>();

                // ���� ���� Player�� ���� ��� ���ο� ������Ʈ�� �߰�
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
