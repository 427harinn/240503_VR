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
        Debug.Log("createAvatar");
        //�A�o�^�[����
        var position = playerRoot.position;
        GameObject avatar = PhotonNetwork.Instantiate("PhotonAvatar", position, Quaternion.identity);

        //�V�[���h����
        GameObject shield = PhotonNetwork.Instantiate("Shield_effect", Vector3.zero, Quaternion.identity);

        //avatar.transform.parent = playerRoot;

        //���������A�o�^�[���Z�b�g
        var trans = avatar.transform.GetChild(0).transform;
        GetComponent<AvatarSyn_s>().SetPhotonAvatarTransform(trans);

        //���������V�[���h���Z�b�g
        GetComponent<SendTransform_s>().SetShieldTransform(shield.transform);

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
}
