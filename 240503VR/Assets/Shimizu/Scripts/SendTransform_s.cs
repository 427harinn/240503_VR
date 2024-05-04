using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SendTransform_s : MonoBehaviour, IPunObservable
{
    //���̃V�[���h�̈ʒu
    Transform OriginShieldTransform;
    //���L����V�[���h�̈ʒu
    Transform shieldTransform = null;
    Defence_s defence_s;
    bool IsSield = false;

    // Start is called before the first frame update
    void Start()
    {
        defence_s = GameObject.Find("Scripts").GetComponent<Defence_s>();
        OriginShieldTransform = GameObject.FindGameObjectWithTag("shield").transform;
        shieldTransform = transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (shieldTransform == null)
        {
            return;
        }
        shieldTransform.gameObject.SetActive(IsSield);
    }

    public void SetShieldTransform(Transform transform)
    {
        shieldTransform = transform;
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
            stream.SendNext(OriginShieldTransform.position);
            stream.SendNext(OriginShieldTransform.rotation);

            IsSield = defence_s.GetIsSield();
            stream.SendNext(IsSield);
        }
        //����̃N���C�A���g���玩�g�̃N���C�A���g�̓����I�u�W�F�N�g�ɑ����Ă�����
        else
        {
            ////shieldTransform.position = (Vector3)stream.ReceiveNext();
            ////shieldTransform.rotation = (Quaternion)stream.ReceiveNext();

            IsSield = (bool)stream.ReceiveNext();
        }
    }
}
