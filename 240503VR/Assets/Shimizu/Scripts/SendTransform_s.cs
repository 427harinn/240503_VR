using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SendTransform_s : MonoBehaviour, IPunObservable
{
    //��
    Transform photonHeadTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        //photonHeadTransform = transform.GetChild(0).gameObject.transform;
        photonHeadTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Transform������肷��
    /// </summary>
    /// <param name="stream">�l�̂������\�ɂ���X�g���[��</param>
    /// <param name="info">�^�C���X�^���v���ׂ̍�����񂪂����\</param>
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //���g�̃N���C�A���g���瑊��N���C�A���g�̓����I�u�W�F�N�g�ɑ�����
        if (stream.IsWriting)
        {
            stream.SendNext(photonHeadTransform.position);
            stream.SendNext(photonHeadTransform.rotation);
        }
        //����̃N���C�A���g���玩�g�̃N���C�A���g�̓����I�u�W�F�N�g�ɑ����Ă�����
        else
        {
            photonHeadTransform.position = (Vector3)stream.ReceiveNext();
            photonHeadTransform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
