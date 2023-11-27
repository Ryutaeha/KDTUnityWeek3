using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public SpriteRenderer Hair;
    public SpriteRenderer Beard;
    public SpriteRenderer Body;
    public SpriteRenderer RArm;
    public SpriteRenderer LArm;
    int LoadSprite;
    // Start is called before the first frame update
    SpriteRenderer SelectObject;
    string Root;
    string ResourcesRoot = "SPUM/SPUM_Sprites/Items/";
    int selecter;
    private void Awake()
    {

    }
    public void Select(int selectNum)
    {
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
        if(selecter > -1 && selecter < 3)
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
}
