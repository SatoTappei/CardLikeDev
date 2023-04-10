using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム終了時の演出を行う
/// </summary>
public class NextTurnEffect : MonoBehaviour
{
    public IEnumerator EffectCoroutine()
    {
        Debug.Log("次のターンへの演出");
        yield return null;
    }
}
