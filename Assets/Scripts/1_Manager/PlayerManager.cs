using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// �v���C���[�̑�����Ǘ�����
/// </summary>
public class PlayerManager : MonoBehaviour
{
    [Header("����{�^��")]
    [SerializeField] Button _submitButton;
    [Header("��")]
    [SerializeField] Transform _field;

    int Player1Selected;
    int Player2Selected;

    void Awake()
    {
        _submitButton.onClick.AddListener(SubmitSelectedCard);
    }

    /// <summary>
    /// Field�̎q�ɂȂ��Ă���J�[�h���擾���邱�ƂŁA�I�������J�[�h��ێ�����
    /// �J�[�h�̑I���̓��[�J���ōs���A�I�������J�[�h�̔ԍ��݂̂𓯊�����
    /// </summary>
    void SubmitSelectedCard()
    {
        int PlayerNum = PhotonNetwork.LocalPlayer.ActorNumber;
        if (!(PlayerNum == 1 || PlayerNum == 2))
        {
            Debug.LogError("ActorNumber���z��O�̒l: " + PlayerNum);
        }

        if (PlayerNum == 1)
        {
            Player1Selected = _field.GetChild(0).GetComponent<Card>().Num;
        }
        else if(PlayerNum == 2)
        {
            Player2Selected = _field.GetChild(0).GetComponent<Card>().Num;
        }
    }
}
