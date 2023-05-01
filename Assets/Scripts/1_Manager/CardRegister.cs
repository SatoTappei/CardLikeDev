using System.Collections;
using System.Collections.Generic;
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

    public Card[] PlayerCards => _playerCards;
    public Card[] EnemyCards => _enemyCards;
}
