using UnityEngine;

/// <summary>
/// ���ꂼ��̃J�[�h�̃f�[�^
/// </summary>
[CreateAssetMenu]
public class CardDataSO : ScriptableObject
{
    [SerializeField] CardTag _tag;
    [SerializeField] string _name;
    [SerializeField] int _num;
    [TextArea]
    [SerializeField] string _ability;

    public string Name { get => _name; }
    public int Num { get => _num; }
    public string Ability { get => _ability; }
    public CardTag Tag { get => _tag; }
}

/// <summary>
/// �J�[�h�̎�ނ𔻕ʂ���ꍇ�Ɏg�p����^�O
/// ���̂Ƃ���g���Ă��Ȃ�
/// </summary>
public enum CardTag
{
    Card1,
    Card2,
    Card3,
    Card4,
    Card5,
    Card6,
    Card7,
    Card8,
    Card9,
    CardSlash,
}