using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class MyHP_s : MonoBehaviour
{
    [SerializeField] Sprite[] HPSprites;
    [SerializeField] Image HPImage;
    [SerializeField] GameObject win;
    [SerializeField] GameObject lose;
    int HP = 25;

    void ChangeImage()
    {
        int index = (int)(HP / 5);
        HPImage.sprite = HPSprites[index];
    }
    
    public void DecHPvalue(bool b, int i = 1)
    {
        if (b && GetComponent<PhotonView>().IsMine)
        {
            return;
        }

        HP -= i;
        if (HP < 0)
        {
            HP = 0;
            lose.SetActive(true);
        }
        ChangeImage();
    }

    public int GetHPvalue()
    {
        return HP;
    }
}
