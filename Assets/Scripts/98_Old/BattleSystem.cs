using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ÿ”s‚Ì”»’è‚ğs‚¤
/// </summary>
public class BattleSystem
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>Ÿ”s‚Ì”»’è‚ğs‚¤</summary>
    /// <returns>Ÿ—˜:1 ”s–k:-1 ˆø‚«•ª‚¯:0</returns>
    public int Battle(CardUnit myself, CardUnit enemy)
    {
        int my = myself.So.Num;
        int ene = enemy.So.Num;

        // ‚Ç‚¿‚ç‚©‚ª0‚Ì‚Íˆø‚«•ª‚¯
        if (my == 0 || ene == 0)
        {
            // ‚Ç‚¿‚ç‚©‚ª0‚Ìê‡‚Í‚»‚¿‚ç‚ÌŸ‚¿
            if (my == 6)
            {
                return 1;
            }
            else if (ene == 6)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        // 8‚Æ1‚Ìê‡‚Í1‚ÌŸ‚¿
        if (my == 8)
        {
            if (ene == 1)
            {
                //‡‚ÉŸ‚Â
            }
        }
        else if (ene == 8)
        {
            if (my == 1)
            {
                //‡‚ÉŸ‚Â
            }
        }

        //‚±‚Ìã‚É“Áê‚È”»’è‚ğ‘S•”ˆ—‚·‚é
        if (my > ene)
        {
            return 1;
        }
        else if (my < ene)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}
