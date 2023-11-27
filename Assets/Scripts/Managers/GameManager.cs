using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text Time;
    // �̱��� �ν��Ͻ��� ������ ���� ����
    private static GameManager instance;
    GameObject Player;
    BtnManager btnManager;
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
        Player = GameObject.Find("Player");
        btnManager = BtnManager.Instance;
    }
    private void Start()
    {
        SceneManager.sceneLoaded += SceneNewLoad;
        Movement movement = Player.GetComponent<Movement>();
        AimRotation aimRotation = Player.GetComponent<AimRotation>();
        movement.MoveSet(false);
        aimRotation.AimSet(false);
    }

    private void Update()
    {
        if (Time != null)
        {
            System.DateTime currentTime = System.DateTime.Now;

            string timeFormat = currentTime.ToString("yy-MM-dd tt hh:mm:ss").Replace("����", "AM").Replace("����", "PM"); ;
            Time.SetText(timeFormat);
        }
    }

    void SceneNewLoad(Scene scene, LoadSceneMode mode)
    {
        TimeSet();
        if(scene.name == "GameScene") btnManager.ButtonSet();
        BtnManager.Instance.OnCharacterInfo();
        BtnManager.Instance.OnCharacterChange();
        BtnManager.Instance.OnNameChangeBtn();
    }

    private void TimeSet()
    {
        GameObject time = GameObject.Find("Time");
        if(time != null) Time = time.GetComponent<TMP_Text>();

    }
    public void PlayerMoveSet(bool moving)
    {   
        Movement movement = Player.GetComponent<Movement>();
        AimRotation aimRotation = Player.GetComponent<AimRotation>();
        movement.MoveSet(moving);
        aimRotation.AimSet(moving);
    }
}
