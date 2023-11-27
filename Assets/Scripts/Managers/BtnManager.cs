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
    public Animator CharacterInfoAni;
    GameObject NameChange;
    GameObject CharacterChange;
    GameObject CharacterInfo;
    GameObject ChangeInfo;
    Button NameChangeBtn;
    Button CharacterChangeBtn;
    Button CharacterInfoBtn;

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
        Debug.Log(CharacterInfoAni.GetBool("IsOpen"));
        if(CharacterInfoAni.GetBool("IsOpen")){
            CharacterInfoAni.SetBool("IsOpen", false);
        }
        else
        {
            CharacterInfoAni.SetBool("IsOpen", true);
        }
        
        /*
        if (CharacterInfo.activeSelf)
        {
            CharacterInfo.SetActive(false);
        }
        else
        {
            CharacterInfo.SetActive(true);
        }
         */
    }
    public void ButtonSet()
    {
        //�̰Ͷ��� �Ѹ� �ϵ� �ڵ��ΰ� �����ϴ�...
        ChangeInfo = GameObject.Find("ChangeInfo");
        NameChange = GameObject.Find("NameChange");
        CharacterChange = GameObject.Find("CharacterChange");
        CharacterInfo = GameObject.Find("CharacterInfo");
        NameChangeBtn = GameObject.Find("NameChangeBtn").transform.GetComponent<Button>();
        CharacterChangeBtn = GameObject.Find("CharacterChangeBtn").transform.GetComponent<Button>();
        CharacterInfoBtn = GameObject.Find("CharacterInfoBtn").transform.GetComponent<Button>();
        CharacterInfoAni = GameObject.Find("CharacterInfo").GetComponent<Animator>();
    }
}
