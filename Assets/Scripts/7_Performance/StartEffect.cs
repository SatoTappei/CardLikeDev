using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームスタート時の演出を行う
/// </summary>
public class StartEffect : MonoBehaviour
{
    public IEnumerator EffectCoroutine()
    {
        Debug.Log("ゲームスタート演出");
        yield return null;
    }
}
