using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム終了時の演出を行う
/// </summary>
public class ResultEffect : MonoBehaviour
{
    public IEnumerator EffectCoroutine()
    {
        Debug.Log("ゲーム終了演出");
        yield return null;
    }
}
