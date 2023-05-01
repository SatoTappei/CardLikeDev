using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;

/// <summary>
/// 両者が選択したカードを保持するクラス
/// 決定ボタンを押した際に場の子になっているカードが決定される
/// </summary>
public class SelectedCardHolder : MonoBehaviourPunCallbacks
{
    /// <summary>
    /// 未選択状態を表す
    /// ゲーム開始時とターン終了時に各プレイヤーはこの状態に戻る
    /// </summary>
    public static readonly int NonSelected = -1;

    [Header("決定ボタン")]
    [SerializeField] Button _submitButton;
    [Header("場")]
    [SerializeField] Transform _field;

    public int Player1Selected { get; private set; }
    public int Player2Selected { get; private set; }

    void Awake()
    {
        _submitButton.onClick.AddListener(SubmitSelectedCard);
        ResetSelectedCard();
    }

    /// <summary>
    /// このメソッドを呼ぶと選択したカードが同期される
    /// カードの選択はローカルで行い、選択したカードの番号のみを同期する
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
    /// 選択したカードをリセットする
    /// 外部からターンの最初に呼ばれる
    /// </summary>
    public void ResetSelectedCard()
    {
        Player1Selected = NonSelected;
        Player2Selected = NonSelected;
    }

    /// <summary>
    /// InGameStream経由でカード選択状態のときに呼ばれる
    /// このメソッドがtrueを返した場合、カード判定の状態に遷移する
    /// </summary>
    public bool IsAllPlayerSelected()
    {
        return Player1Selected != NonSelected && Player2Selected != NonSelected;
    }

    /// <summary>
    /// お互いのプレイヤーが選んだカードの番号が渡されてくる
    /// プレイヤー番号に応じて選択したカードを反映する
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
                    $"プレイヤーを識別するCustomPropertyのキーの値が不正: {prop.Key}");
            }
        }
    }
}