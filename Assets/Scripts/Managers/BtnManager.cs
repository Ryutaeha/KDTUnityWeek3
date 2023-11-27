using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour
{
    public GameObject NameChange;
    public GameObject CharacterChange;
    public GameObject CharacterInfo;
    public GameObject ChangeInfo;
    public Button NameChangeBtn;
    public Button CharacterChangeBtn;
    public Button CharacterInfoBtn;
    string currentSceneName;

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
    /*
     NameChangeBtn.onClick.AddListener(() => movement.MoveSet(false));
            NameChangeBtn.onClick.AddListener(() => aimRotation.AimSet(false));
            CharacterChangeBtn.onClick.AddListener(() => movement.MoveSet(false));
            CharacterChangeBtn.onClick.AddListener(() => aimRotation.AimSet(false));
            CancleBtn.onClick.AddListener(() => movement.MoveSet(true));
            CancleBtn.onClick.AddListener(() => aimRotation.AimSet(true));
            ChangeBtn.onClick.AddListener(() => movement.MoveSet(true));
            ChangeBtn.onClick.AddListener(() => aimRotation.AimSet(true));
     */
    public void OnNameChangeBtn()
    {
        NameChangeBtn.onClick.AddListener(() => PlayerChangeSet(true));
    }
    public void OnCharacterChange()
    {
        CharacterChangeBtn.onClick.AddListener(() => PlayerChangeSet(false));
    }
    public void OnCharacterInfo()
    {
        CharacterInfoBtn.onClick.AddListener(() => CharacterInfoSet());
    }
    public void PlayerChangeSet(bool select)
    {
        ChangeInfo.SetActive(true);
        NameChange.SetActive(select);
        CharacterChange.SetActive(!select);
        GameObject player = GameObject.Find("Player");
        Movement movement = player.GetComponent<Movement>();
        AimRotation aimRotation = player.GetComponent<AimRotation>();
        movement.MoveSet(false);
        aimRotation.AimSet(false);
    }
    public void CharacterInfoSet()
    {
        if(CharacterInfo.activeSelf)
        {
            CharacterInfo.SetActive(false);
        }
        else
        {
            CharacterInfo.SetActive(true);
        }
    }
    public void ButtonSet()
    {
        //이것또한 넘모 하드 코딩인거 같습니다...
        currentSceneName = SceneManager.GetActiveScene().name;
        ChangeInfo = GameObject.Find("ChangeInfo");
        NameChange = GameObject.Find("NameChange");
        CharacterChange = GameObject.Find("CharacterChange");
        CharacterInfo = GameObject.Find("CharacterInfo");
        NameChangeBtn = GameObject.Find("NameChangeBtn").transform.GetComponent<Button>();
        CharacterChangeBtn = GameObject.Find("CharacterChangeBtn").transform.GetComponent<Button>();
        CharacterInfoBtn = GameObject.Find("CharacterInfoBtn").transform.GetComponent<Button>();
    }
}
