using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public TMP_InputField ChangePlayerName;
    public TMP_Text CheckPlayerName;

    public GameObject NameChange;
    public GameObject CharacterChange;

    public TMP_Text PlayerName;
    public SpriteRenderer Hair;
    public SpriteRenderer Beard;
    public SpriteRenderer Body;
    public SpriteRenderer RArm;
    public SpriteRenderer LArm;

    GameObject player;

    string currentSceneName;
    int LoadSprite;

    bool playerCreate;

    SpriteRenderer SelectObject;
    string Root;
    string ResourcesRoot = "SPUM/SPUM_Sprites/Items/";
    public int selecter = -1;
    private void Awake()
    {
        player = GameObject.Find("Player");
        //너무 하드 코딩인데 이거 어떻게 줄일 수 있는 방법이 있습니까 튜터님!!!
        /*
        PlayerName =player.transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>();
        Hair = player.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        Beard = player.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetComponent<SpriteRenderer>();
        Body = player.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        RArm = player.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(3).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        LArm = player.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
         */
        // 플레이어에게 자기자신 값을 주고 해당 값을 찾아오는식으로 변경 이렇게 되면 다음에 다른 코드를 쓸때도 확장성이 더 좋아질수 있다.
        PlayerName = player.GetComponent<Player>().playerName;
        Hair = player.GetComponent<Player>().Hair;
        Beard = player.GetComponent<Player>().Beard;
        Body = player.GetComponent<Player>().Body;
        RArm = player.GetComponent<Player>().RArm;
        LArm = player.GetComponent<Player>().LArm;

        currentSceneName = SceneManager.GetActiveScene().name;
        
    }
    private void Start()
    {
        if (currentSceneName == "GameScene") gameObject.SetActive(false);
    }
    public void Select(int selectNum)
    {
        AudioManager.Instance.PlayAudioClip();
        switch (selectNum)
        {
            case 0: SelectObject = Hair;
                Root = "0_Hair/Hair_";
                break;
            case 1: SelectObject = Beard;
                Root = "1_FaceHair/FaceHair_";
                break;
            case 2: SelectObject = Body;
                Root = "2_Cloth/Cloth_";
                break;
        }
        if(SelectObject.sprite == null)
        {
            LoadSprite = 0;
        }
        else
        {
            if(selectNum == 2) LoadSprite = int.Parse(SelectObject.sprite.texture.name.Substring(SelectObject.sprite.texture.name.Length - 1, 1));
            else LoadSprite = int.Parse(SelectObject.sprite.name.Substring(SelectObject.sprite.name.Length - 1, 1));
            Debug.Log(SelectObject.sprite.texture.name);
        }
        selecter = selectNum;
    }
    public void Change(bool rightleft)
    {
        AudioManager.Instance.PlayAudioClip();
        if (selecter >= 0 && selecter <= 2)
        {
            if(rightleft)
            {
                LoadSprite++;
                if (LoadSprite > 5) LoadSprite = 0;

                if (LoadSprite == 0)
                {
                    if (selecter == 2)
                    {
                        LArm.sprite = null;
                        RArm.sprite = null;
                    }
                    SelectObject.sprite = null;
                }
                else
                {
                    if (selecter == 2)
                    {
                        Sprite[] arm = Resources.LoadAll<Sprite>(ResourcesRoot + Root + LoadSprite);
                        LArm.sprite = arm[1];
                        RArm.sprite = arm[2];
                    }
                    SelectObject.sprite = Resources.Load<Sprite>(ResourcesRoot + Root + LoadSprite);
                    Debug.Log(SelectObject.sprite.name);
                }    
            }
            else
            {
                LoadSprite--;
                if (LoadSprite <= -1) LoadSprite = 5;

                if (LoadSprite == 0)
                {
                    if(selecter == 2)
                    {
                        LArm.sprite = null;
                        RArm.sprite = null;
                    }
                    SelectObject.sprite = null;
                }
                else
                {
                    if(selecter == 2)
                    {
                        Sprite[] arm = Resources.LoadAll<Sprite>(ResourcesRoot + Root + LoadSprite);
                        LArm.sprite = arm[1];
                        RArm.sprite = arm[2];
                    }
                    SelectObject.sprite = Resources.Load<Sprite>(ResourcesRoot + Root + LoadSprite);
                    Debug.Log(SelectObject.sprite.name);
                }
            }
        }

    }


    public void ChangeColor(int selectNum)
    {
        AudioManager.Instance.PlayAudioClip();
        Color choice;
        switch (selectNum)
        {
            case 0:
                choice = Color.red;
                break;
            case 1:
                choice = Color.green;
                break;
            case 2:
                choice = Color.blue;
                break;
            default: choice = Color.black;
                break;
        }
        if(SelectObject.sprite != null)
        {
            SelectObject.color = choice;

            if(selecter ==2)
            {
                RArm.color = choice;
                LArm.color = choice;
            }

        }
    }
    public void UpdateName()
    {
        AudioManager.Instance.PlayAudioClip();
        if (ChangePlayerName == null || string.IsNullOrWhiteSpace(ChangePlayerName.text))
        {
            CheckPlayerName.text = "입력이 안되어있습니다.";
            CheckPlayerName.color = Color.red;
        }
        else
        {
            Regex regex = new Regex("^[가-힣A-Za-z]{2,10}$");

            if (regex.IsMatch(ChangePlayerName.text))
            {
                PlayerName.SetText(ChangePlayerName.text);
                ChangePlayerName.text = "";
                CheckPlayerName.text = "변경되었습니다.";
                CheckPlayerName.color = Color.green;
                if (currentSceneName == "StartScene") playerCreate = true;
                if(SceneManager.GetActiveScene().name == "GameScene") GameManager.Instance.Participant();

            }
            else
            {
                CheckPlayerName.text = "변경조건에 맞지 않습니다.";
                CheckPlayerName.color = Color.red;
                if (currentSceneName == "StartScene") playerCreate = false;
            }
        }
    }
    public void OnChangeBtn()
    {
        AudioManager.Instance.PlayAudioClip();
        if (currentSceneName == "StartScene")
        {
            GameObject parent = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
            if (parent== NameChange)
            {
                if (playerCreate)
                {
                    NameChange.SetActive(false);
                    CharacterChange.SetActive(true);

                }
            }
            else if (parent== CharacterChange)
            {
                Movement movement = player.GetComponent<Movement>();
                AimRotation aimRotation = player.GetComponent<AimRotation>();
                movement.MoveSet(true);
                aimRotation.AimSet(true);
                SceneManager.LoadScene("GameScene");
            }
        }
        else
        {
            GameManager.Instance.PlayerMoveSet(true);
        }
    }
    public void Cancle()
    {
        AudioManager.Instance.PlayAudioClip();
        ChangePlayerName.text = "";
        NameChange.SetActive(false);
        CharacterChange.SetActive(false);
        gameObject.SetActive(false);
        GameManager.Instance.PlayerMoveSet(true);
    }
    
}
