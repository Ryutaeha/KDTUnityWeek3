using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ParticipantNameBox;
    public TMP_Text Time;
    List<GameObject> Participants = new List<GameObject>();
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
        if (scene.name == "GameScene") {
            btnManager.ButtonSet();
        }
            BtnManager.Instance.OnCharacterInfo();
            BtnManager.Instance.OnCharacterChange();
            BtnManager.Instance.OnNameChangeBtn();

            Participant();
    }

    public void Participant()
    {
        if(Participants.Count != 0) DestroyParticipant();
        GameObject[] participantName = GameObject.FindGameObjectsWithTag("NameTag");
        float boxPosition = 130;
        foreach (GameObject participant in participantName)
        {
            Transform Parent = GameObject.Find("CharacterInfo").transform;
            ParticipantNameBox.transform.GetChild(0).GetComponent<TMP_Text>().text = participant.GetComponent<TMP_Text>().text;
            GameObject newParticipantNameBox = Instantiate(ParticipantNameBox, Parent);
            RectTransform newParticipantNameBoxRectTransform = newParticipantNameBox.GetComponent<RectTransform>();

            newParticipantNameBoxRectTransform.anchoredPosition = new Vector2(0, -70f - boxPosition);

            newParticipantNameBox.transform.SetParent(Parent);
            boxPosition += 130;
            Participants.Add(newParticipantNameBox);
        }
    }

    private void DestroyParticipant()
    {
        foreach(GameObject participant in Participants)
        {
            Destroy(participant);
        }
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
