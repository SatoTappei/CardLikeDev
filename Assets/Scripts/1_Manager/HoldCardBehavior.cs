using UniRx;
using UniRx.Triggers;
using UnityEngine;

/// <summary>
/// �莝���̃J�[�h�𑀍삵���Ƃ��̋����̃N���X
/// ��ɏo��/��D�ɖ߂����s��
/// </summary>
public class HoldCardBehavior : MonoBehaviour
{
    [Header("�Q�[�����Ɏg�p����J�[�h")]
    [SerializeField] Card[] _cards;
    [Header("�J�[�h�̑���Ŏg�p����e�I�u�W�F�N�g")]
    [SerializeField] Transform _field;
    [SerializeField] Transform _hand;
    [Header("�v���C���[���Ƃ��Ĉ���")]
    [SerializeField] bool _isPlayerHold;

    void Awake()
    {
        if (_isPlayerHold) InitCardSubscribe();
    }

    /// <summary>
    /// �v���C���[���̏ꍇ�̓J�[�h���}�E�X�N���b�N�ő���o����悤�ɂ���
    /// </summary>
    void InitCardSubscribe()
    {
        foreach (Card card in _cards)
        {
            // IPointer�n�ƈ���ăR���C�_�[��t���Ȃ��Ɣ������Ȃ�
            card.OnMouseUpAsObservable().Subscribe(_ => SwapCard(card.transform));
        }
    }

    /// <summary>
    /// �G���̏ꍇ�́A�����ԂɑJ�ڂ����ۂɊO�����猈�肳�ꂽ�J�[�h��n���đ��삷��K�v������
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
        Debug.Log("�\�[�g");
    }
}
