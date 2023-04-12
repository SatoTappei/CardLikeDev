using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲーム中のカードの制御を行う
/// </summary>
public class CardManager : MonoBehaviour
{
    [Header("ゲーム中に使用するカード")]
    [SerializeField] Card[] _cards;
    [Header("カードの操作で使用する親オブジェクト")]
    [SerializeField] Transform _field;
    [SerializeField] Transform _hand;

    void Awake()
    {
        InitCardSubscribe();
    }

    void InitCardSubscribe()
    {
        foreach (Card card in _cards)
        {
            // IPointer系と違ってコライダーを付けないと反応しない
            card.OnMouseUpAsObservable().Subscribe(_ =>
            {
                ReturnHand();
                SetField(card.transform);
                SortHand();
            });
        }
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
