using DG.Tweening;
using UnityEngine;

/// <summary>
/// DOTweenを用いて画像を波のようにアニメーションさせる
/// 動きがない場面で画面を動かすのに使用する
/// </summary>
public class SpriteWaveAnimation : MonoBehaviour
{
    [Header("動かす画像のTransform")]
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
