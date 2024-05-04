using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SendTransform_s : MonoBehaviour, IPunObservable
{
    //元のシールドの位置
    Transform OriginShieldTransform;
    //共有するシールドの位置
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
    /// Transformをやり取りする
    /// </summary>
    /// <param name="stream">値のやり取りを可能にするストリーム</param>
    /// <param name="info">タイムスタンプ等の細かい情報がやり取り可能</param>
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //自身のクライアントから相手クライアントの同期オブジェクトに送る情報
        if (stream.IsWriting)
        {
            stream.SendNext(OriginShieldTransform.position);
            stream.SendNext(OriginShieldTransform.rotation);

            IsSield = defence_s.GetIsSield();
            stream.SendNext(IsSield);
        }
        //相手のクライアントから自身のクライアントの同期オブジェクトに送られてくる情報
        else
        {
            ////shieldTransform.position = (Vector3)stream.ReceiveNext();
            ////shieldTransform.rotation = (Quaternion)stream.ReceiveNext();

            IsSield = (bool)stream.ReceiveNext();
        }
    }
}
