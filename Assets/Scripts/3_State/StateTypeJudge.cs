using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �I�������J�[�h�𔻒肷����
/// </summary>
public class StateTypeJudge : StateTypeBase
{
    public StateTypeJudge(InGameStream controller) : base(controller)
    {
    }

    protected override void Enter()
    {
        Card c = Controller.GetEnemySelectedCard();
        Debug.Log($"���肪�I�񂾃J�[�h��: {c.Num}");
        // ���葤�̑I�������J�[�h����ɏo�Ă���Animation
    }
}
