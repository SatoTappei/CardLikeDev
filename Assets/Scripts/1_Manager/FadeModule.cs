using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

/// <summary>
/// シーンを遷移する際のフェードを行う
/// </summary>
[System.Serializable]
public class FadeModule
{
    [SerializeField] GameObject gameObject;

    public void FadeOut(UnityAction callback)
    {
        // TODO:ちゃんと作る
        DOVirtual.DelayedCall(0.5f, () => callback?.Invoke())
            .OnStart(() => Debug.Log("フェードアウトします"))
            .OnComplete(() => Debug.Log("フェードアウト終了"))
            .SetLink(gameObject);
    }

    public void FadeIn(UnityAction callback = null)
    {
        // TODO:ちゃんと作る
        DOVirtual.DelayedCall(0.5f, () => callback?.Invoke())
            .OnStart(() => Debug.Log("フェードインします"))
            .OnComplete(() => Debug.Log("フェードイン終了"))
            .SetLink(gameObject);
    }
}
