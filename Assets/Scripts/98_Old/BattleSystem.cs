using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 勝敗の判定を行う
/// </summary>
public class BattleSystem
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>勝敗の判定を行う</summary>
    /// <returns>勝利:1 敗北:-1 引き分け:0</returns>
    //public int Battle(CardController myself, CardController enemy)
    //{
    //    int my = myself.So.Num;
    //    int ene = enemy.So.Num;

    //    // どちらかが0の時は引き分け
    //    if (my == 0 || ene == 0)
    //    {
    //        // どちらかが0の場合はそちらの勝ち
    //        if (my == 6)
    //        {
    //            return 1;
    //        }
    //        else if (ene == 6)
    //        {
    //            return -1;
    //        }
    //        else
    //        {
    //            return 0;
    //        }
    //    }
    //    // 8と1の場合は1の勝ち
    //    if (my == 8)
    //    {
    //        if (ene == 1)
    //        {
    //            //試合に勝つ
    //        }
    //    }
    //    else if (ene == 8)
    //    {
    //        if (my == 1)
    //        {
    //            //試合に勝つ
    //        }
    //    }

    //    //この上に特殊な判定を全部処理する
    //    if (my > ene)
    //    {
    //        return 1;
    //    }
    //    else if (my < ene)
    //    {
    //        return -1;
    //    }
    //    else
    //    {
    //        return 0;
    //    }
    //}
}
