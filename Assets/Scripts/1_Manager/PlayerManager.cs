using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using Photon.Realtime;

/// <summary>
/// プレイヤーの操作を管理する
/// </summary>
public class PlayerManager : MonoBehaviourPunCallbacks
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

        Player1Selected = NonSelected;
        Player2Selected = NonSelected;
    }

    /// <summary>
    /// 静的関数として実装しているので他のクラスでもプレイヤー番号で
    /// カスタムプロパティのキーを取得したい場合はこのメソッドを呼び出すこと
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
            throw new System.ArgumentOutOfRangeException("引数はプレイヤーの番号なので1もしくは2");
        }
    }

    /// <summary>
    /// Fieldの子になっているカードを取得することで、選択したカードを保持する
    /// カードの選択はローカルで行い、選択したカードの番号のみを同期する
    /// </summary>
    void SubmitSelectedCard()
    {
        string key = GetPlayerCustomPropertyKey(PhotonNetwork.LocalPlayer.ActorNumber);

        Hashtable hashtable = new Hashtable();
        hashtable[key] = _field.GetChild(0).GetComponent<Card>().Num;
        PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable);

        // このメソッドを呼ぶと選択したカードが同期されるので
        // 次のターンまでボタンを押せないようにする処理をここに書く
    }

    /// <summary>
    /// InGameStream経由でカード選択状態のときに呼ばれる
    /// このメソッドがtrueを返した場合、カード判定の状態に遷移する
    /// </summary>
    public bool IsAllPlayerSelected()
    {
        return Player1Selected != NonSelected && Player2Selected != NonSelected;
    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        // お互いのプレイヤーが選んだ番号がこのメソッドに入ってくる
        // ここでそれぞれのプレイヤーの番号に反映させたい
        // 今はテストとしてプレイヤーの番号と選んだカード番号を表示している
        foreach (System.Collections.DictionaryEntry prop in propertiesThatChanged)
        {
            Debug.Log($"{prop.Key}: {prop.Value}");
        }
    }
}
