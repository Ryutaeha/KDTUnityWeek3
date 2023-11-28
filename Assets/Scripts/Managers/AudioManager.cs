using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backAudioSource;
    public AudioSource cilpAudioSource;
    public AudioClip btnAudioClip;
    private static AudioManager instance;

    // �ٸ� ��ũ��Ʈ���� BtnManager.Instance�� ������ �� �ֵ��� ������Ƽ ����
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                // �� ������ ã�ƺ��� ������ ���� ����
                instance = FindObjectOfType<AudioManager>();

                if (instance == null)
                {
                    // BtnManager ������Ʈ�� ���� ������ ���� ����
                    GameObject singletonObject = new GameObject("AudioManager");
                    instance = singletonObject.AddComponent<AudioManager>();
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
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(backAudioSource.clip);
        Debug.Log(cilpAudioSource.clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudioClip()
    {
        cilpAudioSource.PlayOneShot(btnAudioClip);
    }
}
