using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// インゲームで使用する両者のカードの状態を登録しておくクラス
/// SelectedCardHolderクラスとHoldCardBehaviorクラスはここから自身の使うカードを参照する
/// </summary>
public class CardRegister : MonoBehaviour
{
    [Header("プレイヤー側のカード")]
    [SerializeField] Card[] _playerCards;
    [Header("敵側のカード")]
    [SerializeField] Card[] _enemyCards;

    public Card[] PlayerCards => _playerCards;
    public Card[] EnemyCards => _enemyCards;
}
