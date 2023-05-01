using UniRx;
using UniRx.Triggers;
using UnityEngine;

/// <summary>
/// 手持ちのカードを操作したときの挙動のクラス
/// 場に出す/手札に戻すを行う
/// </summary>
public class HoldCardBehavior : MonoBehaviour
{
    [Header("ゲーム中に使用するカード")]
    [SerializeField] Card[] _cards;
    [Header("カードの操作で使用する親オブジェクト")]
    [SerializeField] Transform _field;
    [SerializeField] Transform _hand;
    [Header("プレイヤー側として扱う")]
    [SerializeField] bool _isPlayerHold;

    void Awake()
    {
        if (_isPlayerHold) InitCardSubscribe();
    }

    /// <summary>
    /// プレイヤー側の場合はカードをマウスクリックで操作出来るようにする
    /// </summary>
    void InitCardSubscribe()
    {
        foreach (Card card in _cards)
        {
            // IPointer系と違ってコライダーを付けないと反応しない
            card.OnMouseUpAsObservable().Subscribe(_ => SwapCard(card.transform));
        }
    }

    /// <summary>
    /// 敵側の場合は、判定状態に遷移した際に外部から決定されたカードを渡して操作する必要がある
    /// </summary>
    public void SwapCard(Transform card)
    {
        if(_isPlayerHold)

        ReturnHand();
        SetField(card.transform);
        SortHand();
    }

    void SetField(Transform card)
    {
        card.SetParent(_field);
        card.transform.position = _field.position;
    }

    void ReturnHand()
    {
        if (_field.childCount > 0)
        {
            Transform card = _field.GetChild(0);
            card.SetParent(_hand);
        }
    }

    void SortHand()
    {
        Debug.Log("ソート");
    }
}
