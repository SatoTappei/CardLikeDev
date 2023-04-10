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

    bool _isJoinedRoom;
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

        // 1�x�����J�ڂ̏������Ăт����Ȃ��̂őJ�ڒ��̃t���O�𗧂Ă�
        if (PhotonNetwork.CurrentRoom.MaxPlayers == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            _isSceneLoaded = true;
            SceneManager.LoadScene("InGame");
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        _isJoinedRoom = true;

        //Vector3 pos = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        //PhotonNetwork.Instantiate("Circle", pos, Quaternion.identity);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
    }
}
