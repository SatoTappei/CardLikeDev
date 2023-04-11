using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// �Q�[���X�^�[�g���̉��o���s��
/// </summary>
public class StartPerformance : MonoBehaviour
{
    public void Execute(UnityAction callback)
    {
        StartCoroutine(PerformanceCoroutine(callback));
    }

    IEnumerator PerformanceCoroutine(UnityAction callback)
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);

        callback?.Invoke();
    }
}
