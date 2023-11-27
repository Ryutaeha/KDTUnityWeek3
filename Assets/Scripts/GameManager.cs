using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ��� ������ ���� ����
    private static GameManager instance;

    // �ٸ� ��ũ��Ʈ���� ������ �� �ִ� �Ӽ�
    public static GameManager Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ��� ����
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                // ���� ���� GameManager�� ���� ��� ���ο� ������Ʈ�� �߰�
                if (instance == null)
                {
                    GameObject singleton = new GameObject("GameManager");
                    instance = singleton.AddComponent<GameManager>();
                }
            }

            return instance;
        }
    }

    // ���ӸŴ����� ����̳� ���¿� ���� �޼������ �߰��� �� ����

    // ���� �޼���
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
}
