using DG.Tweening;
using UnityEngine;

/// <summary>
/// DOTween��p���ĉ摜��g�̂悤�ɃA�j���[�V����������
/// �������Ȃ���ʂŉ�ʂ𓮂����̂Ɏg�p����
/// </summary>
public class SpriteWaveAnimation : MonoBehaviour
{
    [Header("�������摜��Transform")]
    [SerializeField] Transform _trans;

    void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_trans.DORotate(new Vector3(20, 0, 0), 6.0f)
            .SetEase(Ease.InOutCubic)
            .SetDelay(1.0f))
            .SetLoops(-1, LoopType.Yoyo)
            .SetLink(gameObject);
    }
}
