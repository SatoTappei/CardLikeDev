using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// 各プレイヤーの制御を行う
/// </summary>
public class PlayerUnit : MonoBehaviour
{
    [SerializeField] PlayerCommand _playerCommand;
    [SerializeField] Transform _field;
    [SerializeField] Button _submitButton;
    [SerializeField] Text _counter;
    /// <summary>手持ちのカードは10枚で固定なので配列で管理する</summary>
    [SerializeField] CardUnit[] _cards;

    /// <summary>このターン選択したカード</summary>
    CardUnit _selectedCard;
    /// <summary>現在の勝利数</summary>
    public int WinCount { get; private set; }
    /// <summary>
    /// このターンに出すカードを決定したか
    /// カードを出した状態で決定ボタンを押すとtrueになる
    /// </summary>
    public bool IsSelected { get; private set; }

    void Start()
    {

    }

    void Update()
    {

    }

    public void Init()
    {
        // 決定ボタンにカード選択完了の処理を割り当てる
        _submitButton.onClick.AddListener(() => ClickedSubmitButton());

        foreach (CardUnit card in _cards)
        {
            // 各カードの初期化処理を行う
            card.Init(_field);
            // クリックされたときの処理(場に出す)を登録する
            card.OnClicked += _playerCommand.ToField;
            // ソートできるようにプレイヤーの手札をソート用の辞書に登録する
            _playerCommand.AddSortDic(card.gameObject);
        }

        // 場に出されたことを検知するために子オブジェクトの数が変わった瞬間を検知する
        _field.ObserveEveryValueChanged(t => t.childCount)
              .Skip(1)
              .Subscribe(_ => _submitButton.interactable = true)
              .AddTo(this);
    }

    /// <summary>ターンの初めに1回だけ呼ばれる処理</summary>
    public void TurnStart()
    {
        IsSelected = false;
        // カードを出すまでボタンを押せないようにする
        _submitButton.interactable = false;
        // 全てのカードをアクティブにする
        foreach (CardUnit card in _cards)
            card.Inactive(true);
    }

    /// <summary>ターン終了時に1回だけ呼ばれる処理</summary>
    public void TurnEnd()
    {
        // 処理を書く
        // 場のカードをゴミ箱に移動させる
        _playerCommand.CleanField();
    }

    /// <summary>このターン選択したカードを取得する</summary>
    public CardUnit GetSelectedCard() => _selectedCard;

    /// <summary>
    /// 決定ボタンをクリックしたときの処理
    /// TODO:後々に別の専用場所に移すことを考慮する
    /// </summary>
    void ClickedSubmitButton()
    {
        // 一度押されたらこのターンは押せないようにする
        _submitButton.interactable = false;
        // 出すカードを決定したフラグを立てる
        IsSelected = true;
        // 場の子オブジェクトから取得し、それを選択したカードとする
        _selectedCard = _field.GetComponentInChildren<CardUnit>();

        // 場に出したカード以外を非アクティブ状態にする
        foreach (CardUnit card in _cards)
        {
            // TODO:現状は場の一番目のオブジェクトを取得して選択したカードを見ているが
            //      選択したカードという変数を作ることも考慮する
            if (_selectedCard == card) continue;

            card.Inactive(false);
        }
    }

    /// <summary>このターンのバトルの結果を反映させる</summary>
    public void SetBattleResult(int result)
    {
        // 現状は勝利以外でUIを更新することがない
        if (result != 1) return;
        Debug.Log("よばれる");
        WinCount++;
        _counter.text =WinCount.ToString();
    }
}
