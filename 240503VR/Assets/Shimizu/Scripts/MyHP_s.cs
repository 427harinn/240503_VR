using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyHP_s : MonoBehaviour
{
    [SerializeField] Sprite[] HPSprites;
    Image HPImage;
    private void Start()
    {
        //imageŽæ“¾
    }

    void ChangeImage()
    {

    }

    int HP = 5;
    public void DecHPvalue(int i = 1)
    {
        HP -= i;
        ChangeImage();
    }

    public int GetHPvalue()
    {
        return HP;
    }
}
