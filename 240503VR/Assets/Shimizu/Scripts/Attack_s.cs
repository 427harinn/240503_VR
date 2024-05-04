using Oculus.Interaction.HandGrab.Recorder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using static UnityEngine.GraphicsBuffer;
using System.Numerics;

public class Attack_s : MonoBehaviour
{
    [SerializeField] OVRSkeleton skeletonL;
    [SerializeField] OVRSkeleton skeletonR;
    [SerializeField] Transform OVRHandL;
    [SerializeField] Transform OVRHandR;
    [SerializeField] Transform targetPos;
    //[SerializeField] Transform test;
    //[SerializeField] Transform test1;
    public void OnAttacked()
    {   
        GameObject obj = PhotonNetwork.Instantiate("FireBall", OVRHandR.transform.position, UnityEngine.Quaternion.identity);

        var worldPoint = transform.TransformPoint(targetPos.position);
        UnityEngine.Vector3 vec = (worldPoint - obj.transform.position).normalized;
        //test.position = worldPoint;
        //test1.position = OVRHandR.transform.position;
        //Debug.Log(worldPoint + ":" + obj.transform.position);

        obj.GetComponent<Rigidbody>().AddForce(vec * 500f, ForceMode.Force);

    }
}
