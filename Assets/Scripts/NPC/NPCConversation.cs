using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class NPCConversation : MonoBehaviour
{
    public TMP_Text NPCName;
    public TMP_Text nameText;
    public TMP_Text detailText;
    public GameObject TextBox;
    public GameObject TextBtn;
    public Button EndBtn;
    public TMP_Text NPCText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TextBtn.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TextBtn.SetActive(false);
            TextBox.SetActive(false);

        }
    }
    private void Start()
    {
        TextBtn.GetComponent<Button>().onClick.AddListener(() => gameObject.GetComponent<NPCConversation>().EventNPC());
        EndBtn.onClick.AddListener(()=> gameObject.GetComponent<NPCConversation>().EventNPCEnd());
    }
    public void EventNPC()
    {
        AudioManager.Instance.PlayAudioClip();
        TextBtn.SetActive(false);
        TextBox.SetActive(true);
        nameText.text = NPCName.text;
        detailText.text = NPCText.text;

    }
    public void EventNPCEnd()
    {
        AudioManager.Instance.PlayAudioClip();
        TextBtn.SetActive(true);
        TextBox.SetActive(false);
    }
}
