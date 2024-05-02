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
        // �����_���ȃ��[���ɎQ������
        PhotonNetwork.JoinRandomRoom();
    }

    // �����_���ŎQ���ł��郋�[�������݂��Ȃ��Ȃ�A�V�K�Ń��[�����쐬����
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // ���[���̎Q���l����3�l�ɐݒ肷��
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 3;

        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    public override void OnJoinedRoom()
    {

        if (PhotonNetwork.IsMasterClient)
        {
            //�o�[�W�����Ⴂ�Ŏg���Ȃ�����
            //PhotonNetwork.CurrentRoom.SetStartTime(PhotonNetwork.ServerTimestamp);

            // PhotonNetwork.ServerTimestamp ���g���Č��݂̃^�C���X�^���v���擾
            ExitGames.Client.Photon.Hashtable startTimeProps = new ExitGames.Client.Photon.Hashtable();
            startTimeProps["StartTime"] = PhotonNetwork.ServerTimestamp;

            // ���[���̃J�X�^���v���p�e�B�Ƃ��ĊJ�n������ݒ�
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
