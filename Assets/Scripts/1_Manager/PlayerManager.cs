using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using Photon.Realtime;

/// <summary>
/// �v���C���[�̑�����Ǘ�����
/// </summary>
public class PlayerManager : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// ���I����Ԃ�\��
    /// �Q�[���J�n���ƃ^�[���I�����Ɋe�v���C���[�͂��̏�Ԃɖ߂�
    /// </summary>
    public static readonly int NonSelected = -1;

    [Header("����{�^��")]
    [SerializeField] Button _submitButton;
    [Header("��")]
    [SerializeField] Transform _field;

    public int Player1Selected { get; private set; }
    public int Player2Selected { get; private set; }

    void Awake()
    {
        _submitButton.onClick.AddListener(SubmitSelectedCard);

        Player1Selected = NonSelected;
        Player2Selected = NonSelected;
    }

    /// <summary>
    /// �ÓI�֐��Ƃ��Ď������Ă���̂ő��̃N���X�ł��v���C���[�ԍ���
    /// �J�X�^���v���p�e�B�̃L�[���擾�������ꍇ�͂��̃��\�b�h���Ăяo������
    /// </summary>
    static string GetPlayerCustomPropertyKey(int playerNum)
    {
        if (playerNum == 1)
        {
            return "Player1";
        }
        else if(playerNum == 2)
        {
            return "Player2";
        }
        else
        {
            throw new System.ArgumentOutOfRangeException("�����̓v���C���[�̔ԍ��Ȃ̂�1��������2");
        }
    }

    /// <summary>
    /// Field�̎q�ɂȂ��Ă���J�[�h���擾���邱�ƂŁA�I�������J�[�h��ێ�����
    /// �J�[�h�̑I���̓��[�J���ōs���A�I�������J�[�h�̔ԍ��݂̂𓯊�����
    /// </summary>
    void SubmitSelectedCard()
    {
        string key = GetPlayerCustomPropertyKey(PhotonNetwork.LocalPlayer.ActorNumber);

        Hashtable hashtable = new Hashtable();
        hashtable[key] = _field.GetChild(0).GetComponent<Card>().Num;
        PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable);

        // ���̃��\�b�h���ĂԂƑI�������J�[�h�����������̂�
        // ���̃^�[���܂Ń{�^���������Ȃ��悤�ɂ��鏈���������ɏ���
    }

    /// <summary>
    /// InGameStream�o�R�ŃJ�[�h�I����Ԃ̂Ƃ��ɌĂ΂��
    /// ���̃��\�b�h��true��Ԃ����ꍇ�A�J�[�h����̏�ԂɑJ�ڂ���
    /// </summary>
    public bool IsAllPlayerSelected()
    {
        return Player1Selected != NonSelected && Player2Selected != NonSelected;
    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        // ���݂��̃v���C���[���I�񂾔ԍ������̃��\�b�h�ɓ����Ă���
        // �����ł��ꂼ��̃v���C���[�̔ԍ��ɔ��f��������
        // ���̓e�X�g�Ƃ��ăv���C���[�̔ԍ��ƑI�񂾃J�[�h�ԍ���\�����Ă���
        foreach (System.Collections.DictionaryEntry prop in propertiesThatChanged)
        {
            Debug.Log($"{prop.Key}: {prop.Value}");
        }
    }
}
