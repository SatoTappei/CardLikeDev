using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 他のプレイヤーとのマッチングを行う
/// </summary>
public class MatchingLobby : MonoBehaviourPunCallbacks
{
    [Header("マッチング用のボタン")]
    [SerializeField] Button _matchingButton;

    /// <summary>部屋に入ったか</summary>
    bool _isJoinedRoom;
    /// <summary>既に遷移の処理が呼ばれているか</summary>
    bool _isSceneLoaded;

    void Awake()
    {
        // マッチングボタンを押したらサーバーに接続される
        _matchingButton.onClick.AddListener(() => PhotonNetwork.ConnectUsingSettings());
    }

    void Update()
    {
        // 既に遷移中もしくは部屋に接続できていない状態なら処理を打ち切る
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
