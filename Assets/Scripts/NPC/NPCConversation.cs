using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class NPCConversation : MonoBehaviour
{
    public TMP_Text NPCName;
    public TMP_Text nameText;
    public TMP_Text detailText;
    public GameObject TextBox;
    public GameObject TextBtn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(gameObject.name == "Npc (3)") TextBtn.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.name == "Npc (3)") TextBtn.SetActive(false);
            TextBox.SetActive(false);

        }
    }
    public void EventNPC()
    {
        AudioManager.Instance.PlayAudioClip();
        TextBtn.SetActive(false);
        TextBox.SetActive(true);
        nameText.text = NPCName.text;
        detailText.text = "뭐야 너는 코딩 안해?\n취업안해?";

    }
    public void EventNPCEnd()
    {
        AudioManager.Instance.PlayAudioClip();
        TextBtn.SetActive(true);
        TextBox.SetActive(false);
    }
}
