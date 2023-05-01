using System.Collections.Generic;
using System.Linq;
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

    public IReadOnlyCollection<Card> PlayerCards => _playerCards;
    public IReadOnlyCollection<Card> EnemyCards => _enemyCards;
    Dictionary<int, Card> _playerCardDict = new();
    Dictionary<int, Card> _enemyCardDict = new();

    void Awake()
    {
        _playerCardDict = _playerCards.ToDictionary(c => c.Num, c => c);
        _enemyCardDict = _enemyCards.ToDictionary(c => c.Num, c => c);
    }

    public Card GetPlayerCard(int num) => _playerCardDict[num];
    public Card GetEnemyCard(int num) => _enemyCardDict[num];
}
