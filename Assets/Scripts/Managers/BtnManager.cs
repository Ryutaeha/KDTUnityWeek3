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
        //�̰Ͷ��� �Ѹ� �ϵ� �ڵ��ΰ� �����ϴ�...
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
