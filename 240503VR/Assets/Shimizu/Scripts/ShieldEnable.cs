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
        //���g�̃N���C�A���g���瑊��N���C�A���g�̓����I�u�W�F�N�g�ɑ�����
        if (stream.IsWriting)
        {
            if (photonView.IsMine)
            {
                stream.SendNext(myShild.activeSelf);
            }
            
        }
        //����̃N���C�A���g���玩�g�̃N���C�A���g�̓����I�u�W�F�N�g�ɑ����Ă�����
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
