using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームの進行で使うUIを制御する
/// </summary>
public class CommonUI : MonoBehaviour
{
    [SerializeField] Text _centerText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Init()
    {
        _centerText.text = "";
    }

    // TOOD:対戦させる際には勝った側には勝ち、負けた側には負け
    //      と表示させるようにする
    /// <summary>勝ち負けを表示する</summary>
    public IEnumerator SetBattleResult(int side)
    {
        if(side == 1)
        {
            _centerText.text = "勝ち";
        }
        else if(side == -1)
        {
            _centerText.text = "負け";
        }
        else if(side == 0)
        {
            _centerText.text = "引き分け";
        }

        // TODO:演出を行う
        yield return null;
    }
}
