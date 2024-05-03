using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSkeleton : MonoBehaviour
{
    [SerializeField] private GameObject _HandVisual;
    [SerializeField] private string ovrSkeletonName;//"LeftOVRHand"
    [SerializeField] private Vector3 HandScale;

    private readonly List<Transform> _bonesL = new List<Transform>();
    private List<Transform> _listOfChildren = new List<Transform>();
    private Quaternion _wristFixupRotation;
    private List<OVRBone> _bones;
    OVRSkeleton.IOVRSkeletonDataProvider dataProviderL;

    bool b = true;
    // Start is called before the first frame update
    void Start()
    {
        OVRSkeleton ovrSkeletonL = GameObject.Find(ovrSkeletonName).GetComponent<OVRSkeleton>();
        dataProviderL = ovrSkeletonL.GetComponent<OVRSkeleton.IOVRSkeletonDataProvider>();

        //ボーンの情報をC#で利用可能にするラッパークラス
        OVRPlugin.Skeleton skeleton = new OVRPlugin.Skeleton();

        //ボーンの元データを生成
        OVRPlugin.GetSkeleton((OVRPlugin.SkeletonType)dataProviderL.GetSkeletonType(), out skeleton);
        InitializeBones(skeleton, _HandVisual);

        //正しい順序で生成したボーンのリストを作成
        ReadyHand(_HandVisual, _bonesL);

        _wristFixupRotation = new Quaternion(0.0f, 1.0f, 0.0f, 0.0f);
    }

    private void LateUpdate()
    {
        var _dataL = dataProviderL.GetSkeletonPoseData();

        //左手
        if (_dataL.IsDataValid && _dataL.IsDataHighConfidence)
        {
            //ルートのローカルポジションを適用
            _HandVisual.transform.localPosition = _dataL.RootPose.Position.FromFlippedZVector3f();
            _HandVisual.transform.localRotation = _dataL.RootPose.Orientation.FromFlippedZQuatf();

            //_HandVisual.transform.localScale =
            //    new Vector3(_dataL.RootScale, _dataL.RootScale, _dataL.RootScale);

            //スケールを変化
            _HandVisual.transform.localScale = HandScale;

            //ボーンのリストに受け取った値を反映
            for (int i = 0; i < _bonesL.Count; ++i)
            {
                _bonesL[i].transform.localRotation = _dataL.BoneRotations[i].FromFlippedXQuatf();

                if (_bonesL[i].name == OVRSkeleton.BoneId.Hand_WristRoot.ToString())
                {
                    _bonesL[i].transform.localRotation *= _wristFixupRotation;
                }
            }
        }
    }


    /// <summary>
    /// Bonesを生成
    /// </summary>
    /// <param name="skeleton">あらかじめ用意されたボーンの情報</param>
    /// <param name="hand">左右どちらかの手</param>
    private void InitializeBones(OVRPlugin.Skeleton skeleton, GameObject hand)
    {
        _bones = new List<OVRBone>(new OVRBone[skeleton.NumBones]);

        GameObject _bonesGO = new GameObject("Bones");
        _bonesGO.transform.SetParent(hand.transform, false);
        _bonesGO.transform.localPosition = Vector3.zero;
        _bonesGO.transform.localRotation = Quaternion.identity;

        for (int i = 0; i < skeleton.NumBones; ++i)
        {
            OVRSkeleton.BoneId id = (OVRSkeleton.BoneId)skeleton.Bones[i].Id;
            short parentIdx = skeleton.Bones[i].ParentBoneIndex;
            Vector3 pos = skeleton.Bones[i].Pose.Position.FromFlippedXVector3f();
            Quaternion rot = skeleton.Bones[i].Pose.Orientation.FromFlippedXQuatf();

            GameObject boneGO = new GameObject(id.ToString());
            boneGO.transform.localPosition = pos;
            boneGO.transform.localRotation = rot;
            _bones[i] = new OVRBone(id, parentIdx, boneGO.transform);
        }

        for (int i = 0; i < skeleton.NumBones; ++i)
        {
            if (((OVRPlugin.BoneId)skeleton.Bones[i].ParentBoneIndex) == OVRPlugin.BoneId.Invalid)
            {
                _bones[i].Transform.SetParent(_bonesGO.transform, false);
            }
            else
            {
                _bones[i].Transform.SetParent(_bones[_bones[i].ParentBoneIndex].Transform, false);
            }
        }
    }

    /// <summary>
    /// 手のボーンのリストを作成
    /// 後にOculusの持つボーン情報のリストと照らし合わせて値を更新するので順番に一工夫して作成
    /// </summary>
    /// <param name="hand">子にボーンを持っている手</param>
    /// <param name="bones">空のリスト</param>
    private void ReadyHand(GameObject hand, List<Transform> bones)
    {
        //'Bones'と名の付くオブジェクトからリストを作成する
        foreach (Transform child in hand.transform)
        {
            _listOfChildren = new List<Transform>();
            GetChildRecursive(child.transform);

            //まずは指先以外のリストを作成
            List<Transform> fingerTips = new List<Transform>();
            foreach (Transform bone in _listOfChildren)
            {
                if (bone.name.Contains("Tip"))
                {
                    fingerTips.Add(bone);
                }
                else
                {
                    bones.Add(bone);
                }
            }

            //指先もリストに追加
            foreach (Transform bone in fingerTips)
            {
                bones.Add(bone);
            }
        }

        //動的に生成されるメッシュをSkinnedMeshRendererに反映
        SkinnedMeshRenderer skinMeshRenderer = hand.GetComponent<SkinnedMeshRenderer>();
        OVRMesh ovrMesh = hand.GetComponent<OVRMesh>();

        Matrix4x4[] bindPoses = new Matrix4x4[bones.Count];
        Matrix4x4 localToWorldMatrix = transform.localToWorldMatrix;
        for (int i = 0; i < bones.Count; ++i)
        {
            bindPoses[i] = bones[i].worldToLocalMatrix * localToWorldMatrix;
        }

        //Mesh、SkinnedMeshRendererにBindPose、Boneを反映
        ovrMesh.Mesh.bindposes = bindPoses;
        skinMeshRenderer.bones = bones.ToArray();
        skinMeshRenderer.sharedMesh = ovrMesh.Mesh;
    }

    /// <summary>
    /// 子のオブジェクトのTransformを再帰的に全て取得
    /// </summary>
    /// <param name="obj">自身の子を全て取得したいルートオブジェクト</param>
    private void GetChildRecursive(Transform obj)
    {
        if (null == obj)
            return;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
                continue;

            if (child != obj)
            {
                _listOfChildren.Add(child);
            }

            GetChildRecursive(child);
        }
    }


}
