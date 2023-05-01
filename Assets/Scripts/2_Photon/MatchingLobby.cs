using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// ���̃v���C���[�Ƃ̃}�b�`���O���s��
/// </summary>
public class MatchingLobby : MonoBehaviourPunCallbacks
{
    [Header("�}�b�`���O�p�̃{�^��")]
    [SerializeField] Button _matchingButton;

    /// <summary>�����ɓ�������</summary>
    bool _isJoinedRoom;
    /// <summary>���ɑJ�ڂ̏������Ă΂�Ă��邩</summary>
    bool _isSceneLoaded;

    void Awake()
    {
        // �}�b�`���O�{�^������������T�[�o�[�ɐڑ������
        _matchingButton.onClick.AddListener(() => PhotonNetwork.ConnectUsingSettings());
    }

    void Update()
    {
        // ���ɑJ�ڒ��������͕����ɐڑ��ł��Ă��Ȃ���ԂȂ珈����ł��؂�
        if (_isSceneLoaded || !_isJoinedRoom) return;

        if (PhotonNetwork.CurrentRoom.MaxPlayers == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            _isSceneLoaded = true;
            SceneManager.LoadScene("InGame");
        }
    }

    public override void OnConnectedToMaster() => PhotonNetwork.JoinRandomRoom();

    public override void OnJoinedRoom() => _isJoinedRoom = true;

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
    }
}
