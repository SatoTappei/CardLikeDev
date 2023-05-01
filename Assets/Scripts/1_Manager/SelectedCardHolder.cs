using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;

/// <summary>
/// ���҂��I�������J�[�h��ێ�����N���X
/// ����{�^�����������ۂɏ�̎q�ɂȂ��Ă���J�[�h�����肳���
/// </summary>
public class SelectedCardHolder : MonoBehaviourPunCallbacks
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
        ResetSelectedCard();
    }

    /// <summary>
    /// ���̃��\�b�h���ĂԂƑI�������J�[�h�����������
    /// �J�[�h�̑I���̓��[�J���ōs���A�I�������J�[�h�̔ԍ��݂̂𓯊�����
    /// </summary>
    void SubmitSelectedCard()
    {
        if (_field.childCount == 0)
        {
            GameManager.Instance.PlaySE(AudioType.SE_Cancel);
            return;
        }

        string key = Utility.GetPlayerCustomPropertyKey(PhotonNetwork.LocalPlayer.ActorNumber);
        Hashtable hashtable = new ();
        hashtable[key] = _field.GetChild(0).GetComponent<Card>().Num;
        PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable);

        _submitButton.interactable = false;
    }

    /// <summary>
    /// �I�������J�[�h�����Z�b�g����
    /// �O������^�[���̍ŏ��ɌĂ΂��
    /// </summary>
    public void ResetSelectedCard()
    {
        Player1Selected = NonSelected;
        Player2Selected = NonSelected;
    }

    /// <summary>
    /// InGameStream�o�R�ŃJ�[�h�I����Ԃ̂Ƃ��ɌĂ΂��
    /// ���̃��\�b�h��true��Ԃ����ꍇ�A�J�[�h����̏�ԂɑJ�ڂ���
    /// </summary>
    public bool IsAllPlayerSelected()
    {
        return Player1Selected != NonSelected && Player2Selected != NonSelected;
    }

    /// <summary>
    /// ���݂��̃v���C���[���I�񂾃J�[�h�̔ԍ����n����Ă���
    /// �v���C���[�ԍ��ɉ����đI�������J�[�h�𔽉f����
    /// </summary>
    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        foreach (System.Collections.DictionaryEntry prop in propertiesThatChanged)
        {
            Debug.Log($"{prop.Key}:{prop.Value}");

            if (prop.Key as string == Utility.Player1CustomPropertyKey)
            {
                Player1Selected = (int)prop.Value;
            }
            else if (prop.Key as string == Utility.Player2CustomPropertyKey)
            {
                Player2Selected = (int)prop.Value;
            }
            else
            {
                throw new System.InvalidOperationException(
                    $"�v���C���[�����ʂ���CustomProperty�̃L�[�̒l���s��: {prop.Key}");
            }
        }
    }
}