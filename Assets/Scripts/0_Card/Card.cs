using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// �e�J�[�h�̐�����s��
/// </summary>
public class Card : MonoBehaviour, 
    IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    static float PointerOverDuration = 0.15f;
    static float PointerClickDuration = 0.075f;
    static float ExpansionMag = 1.5f;
    static float ShrinkMag = 0.9f;

    [Header("���̃J�[�h�Ɋ��蓖�Ă�SO")]
    [SerializeField] CardDataSO _so;
    [Header("���葤�̃J�[�h�Ƃ��Ĉ���")]
    [SerializeField] bool _isOtherSide;

    Image _sprite;
    bool _isSelectable;

    void Awake()
    {
        _sprite = GetComponentInChildren<Image>();
        // ���葤�̃J�[�h�̏ꍇ�̓v���C���[���N���b�N�o���Ȃ��悤�ɂ���
        _isSelectable = !_isOtherSide ? true : false;
    }

    /// <summary>�O�����炱�̃��\�b�h���Ă�őI���\����؂�ւ���</summary>
    public void Inactive(bool value)
    {
        _sprite.color = value ? Color.white : Color.black;
        _isSelectable = value ? true : false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_isSelectable)
        {
            _sprite.transform.DOScale(new Vector3(ExpansionMag, ExpansionMag, 1), PointerOverDuration);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_isSelectable)
        {
            _sprite.transform.DOScale(Vector3.one, PointerOverDuration);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isSelectable)
        {
            _sprite.transform.DOScale(new Vector3(ShrinkMag, ShrinkMag, 1), PointerClickDuration);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_isSelectable)
        {
            _sprite.transform.DOScale(Vector3.one, PointerClickDuration);
        }
    }
}
