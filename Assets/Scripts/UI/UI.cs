using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private GameObject player;
    public GameObject ChangeInfo;
    public GameObject NameChange;
    public GameObject CharacterChange;
    public TMP_Text Time;
    public TMP_Text PlayerName;
    public TMP_InputField ChangePlayerName;
    public TMP_Text CheckPlayerName;
    public Button NameChangeBtn;
    public Button CharacterChangeBtn;
    public Button ChangeBtn;
    public Button CancleBtn;

    private static UI instance;

    // 다른 스크립트에서 접근할 수 있는 속성
    public static UI Instance
    {
        get
        {
            // 인스턴스가 없을 경우 생성
            if (instance == null)
            {
                instance = FindObjectOfType<UI>();

                // 게임 내에 UI가 없는 경우 새로운 오브젝트에 추가
                if (instance == null)
                {
                    GameObject singleton = new GameObject("UI");
                    instance = singleton.AddComponent<UI>();
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
    private void Start()
    {

        player = GameObject.Find("Player");
        if (player != null)
        {
            Transform playerName = player.transform.Find("Canvas/Name");
            PlayerName = playerName.transform.GetComponent<TMP_Text>();
            Movement movement = player.GetComponent<Movement>();
            AimRotation aimRotation = player.GetComponent<AimRotation>();
            
            NameChangeBtn.onClick.AddListener(() => movement.MoveSet(false));
            NameChangeBtn.onClick.AddListener(() => aimRotation.AimSet(false));
            CharacterChangeBtn.onClick.AddListener(() => movement.MoveSet(false));
            CharacterChangeBtn.onClick.AddListener(() => aimRotation.AimSet(false));
            CancleBtn.onClick.AddListener(() => movement.MoveSet(true));
            CancleBtn.onClick.AddListener(() => aimRotation.AimSet(true));
            ChangeBtn.onClick.AddListener(() => movement.MoveSet(true));
            ChangeBtn.onClick.AddListener(() => aimRotation.AimSet(true));
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        System.DateTime currentTime = System.DateTime.Now;

        string timeFormat = currentTime.ToString("yy-MM-dd tt hh:mm:ss").Replace("오전", "AM").Replace("오후", "PM"); ;
        Time.SetText(timeFormat);
    }
    public void UpdateName()
    {
        if(ChangePlayerName == null || string.IsNullOrWhiteSpace(ChangePlayerName.text))
        {
            CheckPlayerName.text = "입력이 안되어있습니다.";
            CheckPlayerName.color = Color.red;
        }
        else
        {
            Regex regex = new Regex("^[가-힣A-Za-z]{2,10}$");

            if(regex.IsMatch(ChangePlayerName.text))
            {
                PlayerName.SetText(ChangePlayerName.text);
                ChangePlayerName.text = "";
                CheckPlayerName.text = "변경되었습니다.";
                CheckPlayerName.color = Color.green;
            }
            else
            {
                CheckPlayerName.text = "변경조건에 맞지 않습니다.";
                CheckPlayerName.color = Color.red;
            }
        }
    }
    public void UpdateCharacter()
    {

    }
    public void Cancel()
    {
        ChangePlayerName.text = "";
        ChangeInfo.SetActive(false);
        NameChange.SetActive(false);
        CharacterChange.SetActive(false);
    }
    public void NameChangeView()
    {
        ChangeInfo.SetActive(true);
        NameChange.SetActive(true);
    }
    public void CharacterChangeView()
    {
        ChangeInfo.SetActive(true);
        CharacterChange.SetActive(true);
    }

}
