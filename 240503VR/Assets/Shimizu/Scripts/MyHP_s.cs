using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class MyHP_s : MonoBehaviourPunCallbacks
{
    [SerializeField] Sprite[] HPSprites;
    [SerializeField] Image HPImage;
    [SerializeField] GameObject win;
    [SerializeField] GameObject lose;
    int myHP = 5;
    int otherHP = 5;
    int[] HPs = new int[2];

    void ChangeImage()
    {
        //int index = (int)(myHP / 5);
        HPImage.sprite = HPSprites[myHP];
    }
    
    public void DecHPvalue(int i = 1)
    {
        myHP -= i;
        if (myHP < 0)
        {
            myHP = 0;
            losedef();
        }
        SynHP();
        ChangeImage();
        
    }

    public int GetHPvalue()
    {
        return myHP;
    }

    public void losedef()
    {
        lose.SetActive(true);
    }

    public void windef()
    {
        win.SetActive(true);
    }

    [PunRPC]
    void Rpc(int[] hps)
    {
        myHP = hps[0];
        otherHP = hps[1];

        if (myHP == 0)
        {
            losedef();
        }
    }

    public void SynHP()
    {
        HPs[0] = myHP;
        HPs[1] = otherHP;
        photonView.RPC(nameof(Rpc), RpcTarget.All, HPs);
    }
}
