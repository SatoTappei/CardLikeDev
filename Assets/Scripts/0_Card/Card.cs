using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 各カードの制御を行う
/// </summary>
public class Card : MonoBehaviour, 
    IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    static float PointerOverDuration = 0.15f;
    static float PointerClickDuration = 0.075f;
    static float ExpansionMag = 1.5f;
    static float ShrinkMag = 0.9f;

    [Header("このカードに割り当てるSO")]
    [SerializeField] CardDataSO _so;
    [Header("相手側のカードとして扱う")]
    [SerializeField] bool _isOtherSide;

    Image _sprite;
    bool _isSelectable;

    void Awake()
    {
        _sprite = GetComponentInChildren<Image>();
        // 相手側のカードの場合はプレイヤーがクリック出来ないようにする
        _isSelectable = !_isOtherSide ? true : false;
    }

    /// <summary>外部からこのメソッドを呼んで選択可能かを切り替える</summary>
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
