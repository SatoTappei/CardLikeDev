using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

/// <summary>
/// ゲームスタート時の演出を行う
/// </summary>
public class StartPerformance : MonoBehaviour
{
    [SerializeField] GameObject _startPerformance;
    [SerializeField] RectTransform _player1Root;
    [SerializeField] RectTransform _player2Root;

    void Awake()
    {
        _player1Root.DOAnchorPosY(-650.0f, 0f);
        _player2Root.DOAnchorPosY(650.0f, 0f);
    }

    public void Execute(UnityAction callback)
    {
        StartCoroutine(PerformanceCoroutine(callback));
    }

    IEnumerator PerformanceCoroutine(UnityAction callback)
    {
        yield return new WaitForSeconds(0.5f);
        _startPerformance.SetActive(false);
        _player1Root.DOAnchorPosY(-350.0f, 0.5f).SetEase(Ease.InQuad);
        _player2Root.DOAnchorPosY(350.0f, 0.5f).SetEase(Ease.InQuad);

        callback?.Invoke();
    }
}
