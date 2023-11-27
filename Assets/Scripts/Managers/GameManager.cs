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
    // 싱글톤 인스턴스를 저장할 정적 변수
    private static GameManager instance;
    GameObject Player;
    BtnManager btnManager;
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

            string timeFormat = currentTime.ToString("yy-MM-dd tt hh:mm:ss").Replace("오전", "AM").Replace("오후", "PM"); ;
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
