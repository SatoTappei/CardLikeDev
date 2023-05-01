using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 選択したカードを判定する状態
/// </summary>
public class StateTypeJudge : StateTypeBase
{
    public StateTypeJudge(InGameStream controller) : base(controller)
    {
    }

    protected override void Enter()
    {
        Card c = Controller.GetEnemySelectedCard();
        Debug.Log($"相手が選んだカードは: {c.Num}");
        // 相手側の選択したカードが場に出てくるAnimation
    }
}
