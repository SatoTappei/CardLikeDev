using UnityEngine;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

/// <summary>
/// インゲームの各状態の列挙型
/// </summary>
public enum StateType
{
    StartPerformance,
    CardSelect,
    Judge,
    TurnResult,
    NextTurnPerformance,
    EndPerformance,
}

/// <summary>
/// ゲームプレイの進行をステートベースで制御する
/// </summary>
public class InGameStream : MonoBehaviourPunCallbacks
{
    [SerializeField] StartPerformance _startPerformance;
    [SerializeField] Text _text;

    Dictionary<StateType, StateTypeBase> _stateDic = new Dictionary<StateType, StateTypeBase>();
    StateTypeBase _currentState;

    void Awake()
    {
        StateTypeStartPerformance stateTypeStartPerformance = new(this, _startPerformance);
        StateTypeCardSelect stateTypeCardSelect = new(this);

        _stateDic.Add(StateType.StartPerformance, stateTypeStartPerformance);
        _stateDic.Add(StateType.CardSelect, stateTypeCardSelect);

        _currentState = stateTypeStartPerformance;
    }

    void Start()
    {
        _text.text = PhotonNetwork.LocalPlayer.ActorNumber.ToString();
    }

    void Update()
    {
        _currentState = _currentState.Execute();
    }

    // プレイヤーがカードを出した時のコールバックとして登録する
    void SendPlayerCard()
    {
        // プレイヤーが選択してカードの番号を送る
        photonView.RPC(nameof(RPCOnRecievedCard), RpcTarget.Others, 1994);
    }

    [PunRPC]
    void RPCOnRecievedCard(int number)
    {
        Debug.Log(number);
    }

    public StateTypeBase GetState(StateType type) => _stateDic[type];

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log($"{otherPlayer.NickName}が退出しました");
    }
}
