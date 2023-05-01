using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// �C���Q�[���Ŏg�p���闼�҂̃J�[�h�̏�Ԃ�o�^���Ă����N���X
/// SelectedCardHolder�N���X��HoldCardBehavior�N���X�͂������玩�g�̎g���J�[�h���Q�Ƃ���
/// </summary>
public class CardRegister : MonoBehaviour
{
    [Header("�v���C���[���̃J�[�h")]
    [SerializeField] Card[] _playerCards;
    [Header("�G���̃J�[�h")]
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
