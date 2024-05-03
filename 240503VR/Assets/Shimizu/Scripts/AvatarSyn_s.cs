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
    [SerializeField] Transform handLTransform;
    [SerializeField] Transform handRTransform;
    [SerializeField] OVRSkeleton skeletonL;
    [SerializeField] OVRSkeleton skeletonR;
    ////生成したアバター(親)
    //Transform photonAvatarTransform = null;
    //頭
    Transform photonHeadTransform = null;
    //左手
    Transform photonHandLTransform = null;
    //右手
    Transform photonHandRTransform = null;


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
        if (photonHeadTransform == null || photonHandLTransform == null || photonHandRTransform == null)
        {
            return;
        }

        //位置を同期
        SynTransform();
    }

    public void SetPhotonAvatarTransform(Transform rootTrans)
    {
        //自分のアバターを設定
        //photonAvatarTransform = rootTrans;
        photonHeadTransform = rootTrans;
        photonHandLTransform = rootTrans.GetChild(0).transform;
        photonHandRTransform = rootTrans.GetChild(1).transform;
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

        Vector3 [] handPosL = getHandPositions(skeletonL);
        Vector3[] handPosR = getHandPositions(skeletonR);

        if (handPosL != null)
        {
            //左手の位置
            photonHandLTransform.position = handPosL[5];
            //左手の回転
            photonHandLTransform.rotation = handLTransform.rotation;
        }

        if (handPosR != null)
        {
            //左手の位置
            photonHandRTransform.position = handPosR[5];
            //Debug.Log(cameraTransform.position);
            //左手の回転
            photonHandRTransform.rotation = handRTransform.rotation;
        }

        //test.position = handLTransform.position;
        //test.rotation = handLTransform.rotation;
    }

    public Vector3[] getHandPositions(OVRSkeleton skeleton)
    {

        var usingHand = OVRInput.IsControllerConnected(OVRInput.Controller.Hands);
        //var usingTouch = OVRInput.IsControllerConnected(OVRInput.Controller.Touch);

        if (!usingHand)
        {
            return null;
        }

        Vector3 palmPosition = (
            skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_Thumb0].Transform.position +
            skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_Index1].Transform.position +
            skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_Middle1].Transform.position +
            skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_Ring1].Transform.position +
            skeleton.Bones[(int)OVRSkeleton.BoneId.Hand_Pinky0].Transform.position
            ) / 5;
        return new Vector3[]{
        skeleton.Bones[(int) OVRSkeleton.BoneId.Hand_Thumb3].Transform.position,
        skeleton.Bones[(int) OVRSkeleton.BoneId.Hand_Index3].Transform.position,
        skeleton.Bones[(int) OVRSkeleton.BoneId.Hand_Middle3].Transform.position,
        skeleton.Bones[(int) OVRSkeleton.BoneId.Hand_Ring3].Transform.position,
        skeleton.Bones[(int) OVRSkeleton.BoneId.Hand_Pinky3].Transform.position,
        palmPosition
        };
    }
}
