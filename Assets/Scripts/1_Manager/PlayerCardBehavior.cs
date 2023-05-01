using UniRx;
using UniRx.Triggers;
using UnityEngine;

/// <summary>
/// �v���C���[�̃J�[�h���}�E�X�ő��삵���Ƃ��̋����̃N���X
/// ��ɏo��/��D�ɖ߂����s��
/// </summary>
public class PlayerCardBehavior : MonoBehaviour
{
    [Header("�Q�[�����Ɏg�p����J�[�h")]
    [SerializeField] Card[] _cards;
    [Header("�J�[�h�̑���Ŏg�p����e�I�u�W�F�N�g")]
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
