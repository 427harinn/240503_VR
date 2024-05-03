using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SendTransform_s : MonoBehaviour, IPunObservable
{
    //頭
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
    /// Transformをやり取りする
    /// </summary>
    /// <param name="stream">値のやり取りを可能にするストリーム</param>
    /// <param name="info">タイムスタンプ等の細かい情報がやり取り可能</param>
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //自身のクライアントから相手クライアントの同期オブジェクトに送る情報
        if (stream.IsWriting)
        {
            stream.SendNext(photonHeadTransform.position);
            stream.SendNext(photonHeadTransform.rotation);
        }
        //相手のクライアントから自身のクライアントの同期オブジェクトに送られてくる情報
        else
        {
            photonHeadTransform.position = (Vector3)stream.ReceiveNext();
            photonHeadTransform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
