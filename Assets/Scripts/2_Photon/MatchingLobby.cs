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

    bool _isJoinedRoom;
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

        // 1度しか遷移の処理を呼びたくないので遷移中のフラグを立てる
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
