using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [Header("ゲーム中に使用するカード")]
    [SerializeField] Card[] _cards;
    [SerializeField] Transform _field;
    [SerializeField] Transform _hand;

    void Awake()
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
