using Oculus.Interaction.HandGrab.Recorder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_s : MonoBehaviour
{
    [SerializeField] OVRSkeleton skeletonL;
    [SerializeField] OVRSkeleton skeletonR;
    [SerializeField] Transform OVRHandL;
    [SerializeField] Transform OVRHandR;
    public void OnAttacked()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("FireBall"));
        obj.transform.position = OVRHandR.transform.position;

        obj.GetComponent<Rigidbody>().AddForce(Vector3.forward * 800f, ForceMode.Force);

    }
}
