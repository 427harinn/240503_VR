using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MatchManager_s: MonoBehaviourPunCallbacks
{
    [SerializeField] string nickName;
    [SerializeField] Transform playerRoot;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "0.1";
        PhotonNetwork.NickName = nickName;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        // ランダムなルームに参加する
        PhotonNetwork.JoinRandomRoom();
    }

    // ランダムで参加できるルームが存在しないなら、新規でルームを作成する
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // ルームの参加人数を3人に設定する
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 3;

        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("createAvatar");
        //アバター生成
        var position = playerRoot.position;
        GameObject avatar = PhotonNetwork.Instantiate("PhotonAvatar", position, Quaternion.identity);

        //シールド生成
        GameObject shield = PhotonNetwork.Instantiate("Shield_effect", Vector3.zero, Quaternion.identity);

        //avatar.transform.parent = playerRoot;

        //生成したアバターをセット
        var trans = avatar.transform.GetChild(0).transform;
        GetComponent<AvatarSyn_s>().SetPhotonAvatarTransform(trans);

        //生成したシールドをセット
        GetComponent<SendTransform_s>().SetShieldTransform(shield.transform);

        if (PhotonNetwork.IsMasterClient)
        {
            //バージョン違いで使えなかった
            //PhotonNetwork.CurrentRoom.SetStartTime(PhotonNetwork.ServerTimestamp);

            // PhotonNetwork.ServerTimestamp を使って現在のタイムスタンプを取得
            ExitGames.Client.Photon.Hashtable startTimeProps = new ExitGames.Client.Photon.Hashtable();
            startTimeProps["StartTime"] = PhotonNetwork.ServerTimestamp;

            // ルームのカスタムプロパティとして開始時刻を設定
            PhotonNetwork.CurrentRoom.SetCustomProperties(startTimeProps);
        }
    }
}
