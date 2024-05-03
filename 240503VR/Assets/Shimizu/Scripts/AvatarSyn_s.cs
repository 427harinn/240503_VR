using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class AvatarSyn_s : MonoBehaviour
{
    ////CameraRig
    //[SerializeField] Transform playerTransform;
    //Camera
    [SerializeField] Transform cameraTransform;
    ////���������A�o�^�[(�e)
    //Transform photonAvatarTransform = null;
    //��
    Transform photonHeadTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (!photonView.IsMine)
        //{
        //    return;
        //}

        //if (photonAvatarTransform == null || photonHeadTransform == null)
        if (photonHeadTransform == null)
        {
            return;
        }

        //�ʒu�𓯊�
        SynTransform();
    }

    public void SetPhotonAvatarTransform(Transform rootTrans, Transform headTrans)
    {
        //�����̃A�o�^�[��ݒ�
        //photonAvatarTransform = rootTrans;
        photonHeadTransform = headTrans;
    }

    void SynTransform()
    {
        ////�e�I�u�W�F�N�g�̈ʒu
        //photonAvatarTransform.position = new Vector3(
        //    playerTransform.position.x, 1, playerTransform.position.z);
        ////�e�I�u�W�F�N�g�̉�]
        //photonAvatarTransform.rotation = playerTransform.rotation;

        //���̈ʒu
        photonHeadTransform.position = cameraTransform.position;
        //Debug.Log(cameraTransform.position);
        //���̉�]
        photonHeadTransform.rotation = cameraTransform.rotation;
    }
}
