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

    // ´Ù¸¥ ½ºÅ©¸³Æ®¿¡¼­ Á¢±ÙÇÒ ¼ö ÀÖ´Â ¼Ó¼º
    public static UI Instance
    {
        get
        {
            // ÀÎ½ºÅÏ½º°¡ ¾øÀ» °æ¿ì »ý¼º
            if (instance == null)
            {
                instance = FindObjectOfType<UI>();

                // °ÔÀÓ ³»¿¡ UI°¡ ¾ø´Â °æ¿ì »õ·Î¿î ¿ÀºêÁ§Æ®¿¡ Ãß°¡
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
        // ¾À ÀüÈ¯ ½Ã ÀÎ½ºÅÏ½º°¡ À¯ÁöµÇµµ·Ï ¼³Á¤
        DontDestroyOnLoad(gameObject);

        // ÀÌ¹Ì ÀÎ½ºÅÏ½º°¡ Á¸ÀçÇÏ´Â °æ¿ì Áßº¹ »ý¼º ¹æÁö
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

        string timeFormat = currentTime.ToString("yy-MM-dd tt hh:mm:ss").Replace("¿ÀÀü", "AM").Replace("¿ÀÈÄ", "PM"); ;
        Time.SetText(timeFormat);
    }
    public void UpdateName()
    {
        if(ChangePlayerName == null || string.IsNullOrWhiteSpace(ChangePlayerName.text))
        {
            CheckPlayerName.text = "ÀÔ·ÂÀÌ ¾ÈµÇ¾îÀÖ½À´Ï´Ù.";
            CheckPlayerName.color = Color.red;
        }
        else
        {
            Regex regex = new Regex("^[°¡-ÆRA-Za-z]{2,10}$");

            if(regex.IsMatch(ChangePlayerName.text))
            {
                PlayerName.SetText(ChangePlayerName.text);
                ChangePlayerName.text = "";
                CheckPlayerName.text = "º¯°æµÇ¾ú½À´Ï´Ù.";
                CheckPlayerName.color = Color.green;
            }
            else
            {
                CheckPlayerName.text = "º¯°æÁ¶°Ç¿¡ ¸ÂÁö ¾Ê½À´Ï´Ù.";
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
