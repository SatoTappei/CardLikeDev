using UnityEngine;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

/// <summary>
/// �C���Q�[���̊e��Ԃ̗񋓌^
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
/// �Q�[���v���C�̐i�s���X�e�[�g�x�[�X�Ő��䂷��
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

    // �v���C���[���J�[�h���o�������̃R�[���o�b�N�Ƃ��ēo�^����
    void SendPlayerCard()
    {
        // �v���C���[���I�����ăJ�[�h�̔ԍ��𑗂�
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
        Debug.Log($"{otherPlayer.NickName}���ޏo���܂���");
    }
}
