using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Observe_s : MonoBehaviourPunCallbacks
{
    [SerializeField] string nickName;
    // Start is called before the first frame update
    void Start()
    {
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

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Enter => " + newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player player)
    {
        Debug.Log("left => " + player.NickName);
    }
}
