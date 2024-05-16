using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class ShieldEnable : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] GameObject myShild;

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //自身のクライアントから相手クライアントの同期オブジェクトに送る情報
        if (stream.IsWriting)
        {
            if (photonView.IsMine)
            {
                stream.SendNext(myShild.activeSelf);
            }
            
        }
        //相手のクライアントから自身のクライアントの同期オブジェクトに送られてくる情報
        else
        {
            if (!photonView.IsMine)
            {
                bool f = (bool)stream.ReceiveNext();
                myShild.SetActive(f);
            }
            
        }
    }

}
