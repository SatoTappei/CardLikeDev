using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// 各カードの制御を行う
/// </summary>
public class CardUnit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    /// <summary>カードの画像</summary>
    [SerializeField] Image _sprite;
    /// <summary>SOを取得するのに使用するタグ</summary>
    [Header("SOを取得してくるためのタグ")]
    [SerializeField] CardTag _cardTag;

    Transform _field;
    /// <summary>選択可能かのフラグ</summary>
    bool _isSelectable;

    // SOは外部から参照できるようにしておく
    public CardDataSO So { get; private set; }

    /// <summary>クリックされたときに行う処理を外部から追加できるようにしておく</summary>
    public UnityAction<Transform> OnClicked;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>初期化処理</summary>
    public void Init(Transform field)
    {
        _field = field;
        So = CardDataManager.GetSO(_cardTag);
        _isSelectable = true;
        // TOOD: _soのデータを実際のカードに反映する処理
    }

    /// <summary>選択可能かを切り替える</summary>
    public void Inactive(bool value)
    {
        _sprite.color = value ? Color.white : Color.black;
        _isSelectable = value ? true : false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_isSelectable)
        {
            _sprite.transform.DOScale(new Vector3(1.5f, 1.5f, 1), 0.15f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_isSelectable)
        {
            _sprite.transform.DOScale(Vector3.one, 0.15f);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 場にいる時にクリックできないようにする
        if (_isSelectable && transform.parent != _field)
        {
            // クリックされた時の処理(場に出す)を実行する
            OnClicked?.Invoke(transform);
        }
    }
}
