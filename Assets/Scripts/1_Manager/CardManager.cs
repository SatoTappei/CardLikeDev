using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [Header("�Q�[�����Ɏg�p����J�[�h")]
    [SerializeField] Card[] _cards;
    [SerializeField] Transform _field;
    [SerializeField] Transform _hand;

    void Awake()
    {
        foreach (Card card in _cards)
        {
            // IPointer�n�ƈ���ăR���C�_�[��t���Ȃ��Ɣ������Ȃ�
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
        Debug.Log("�\�[�g");
    }
}
