using Oculus.Interaction.HandGrab.Recorder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Attack_s : MonoBehaviour
{
    [SerializeField] OVRSkeleton skeletonL;
    [SerializeField] OVRSkeleton skeletonR;
    [SerializeField] Transform OVRHandL;
    [SerializeField] Transform OVRHandR;
    [SerializeField] Transform targetPos;
    public void OnAttacked()
    {   
        GameObject obj = PhotonNetwork.Instantiate("FireBall", OVRHandR.transform.position, Quaternion.identity);

        obj.GetComponent<Rigidbody>().AddForce(targetPos.position * 500f, ForceMode.Force);

    }
}
