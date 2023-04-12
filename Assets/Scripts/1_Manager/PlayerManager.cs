using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

/// <summary>
/// プレイヤーの操作を管理する
/// </summary>
public class PlayerManager : MonoBehaviour
{
    [Header("決定ボタン")]
    [SerializeField] Button _submitButton;
    [Header("場")]
    [SerializeField] Transform _field;

    int Player1Selected;
    int Player2Selected;

    void Awake()
    {
        _submitButton.onClick.AddListener(SubmitSelectedCard);
    }

    /// <summary>
    /// Fieldの子になっているカードを取得することで、選択したカードを保持する
    /// カードの選択はローカルで行い、選択したカードの番号のみを同期する
    /// </summary>
    void SubmitSelectedCard()
    {
        int PlayerNum = PhotonNetwork.LocalPlayer.ActorNumber;
        if (!(PlayerNum == 1 || PlayerNum == 2))
        {
            Debug.LogError("ActorNumberが想定外の値: " + PlayerNum);
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
