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
    ////生成したアバター(親)
    //Transform photonAvatarTransform = null;
    //頭
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

        //位置を同期
        SynTransform();
    }

    public void SetPhotonAvatarTransform(Transform rootTrans, Transform headTrans)
    {
        //自分のアバターを設定
        //photonAvatarTransform = rootTrans;
        photonHeadTransform = headTrans;
    }

    void SynTransform()
    {
        ////親オブジェクトの位置
        //photonAvatarTransform.position = new Vector3(
        //    playerTransform.position.x, 1, playerTransform.position.z);
        ////親オブジェクトの回転
        //photonAvatarTransform.rotation = playerTransform.rotation;

        //頭の位置
        photonHeadTransform.position = cameraTransform.position;
        //Debug.Log(cameraTransform.position);
        //頭の回転
        photonHeadTransform.rotation = cameraTransform.rotation;
    }
}
