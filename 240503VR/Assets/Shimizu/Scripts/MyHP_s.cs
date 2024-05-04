using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyHP_s : MonoBehaviour
{
    [SerializeField] Sprite[] HPSprites;
    [SerializeField] Image HPImage;
    int HP = 5;

    void ChangeImage()
    {
        HPImage.sprite = HPSprites[HP];
    }
    
    public void DecHPvalue(int i = 1)
    {
        HP -= i;
        if (HP < 0)
        {
            HP = 0;
        }
        ChangeImage();
    }

    public int GetHPvalue()
    {
        return HP;
    }
}
