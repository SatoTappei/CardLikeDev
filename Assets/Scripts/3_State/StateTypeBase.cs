using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームの各状態の基底クラス
/// 各状態はこのクラスを継承して作成する
/// </summary>
public class StateTypeBase
{
    enum Stage
    {
        Enter,
        Stay,
        Exit,
    }

    Stage _stage;
    StateTypeBase _nextState;
    InGameStream _controller;

    public StateTypeBase(InGameStream inGameStream)
    {
        _controller = inGameStream;
    }

    public void Execute()
    {
        if (_stage == Stage.Enter)
        {
            Enter();
            _stage = Stage.Stay;
        }
        else if (_stage == Stage.Stay)
        {
            Stay();
        }
        else if (_stage == Stage.Exit)
        {
            Exit();
            _stage = Stage.Enter;
        }
    }

    protected virtual void Enter() { }
    protected virtual void Stay() { }
    protected virtual void Exit() { }

    /// <summary>
    /// 次の状態に遷移する
    /// 先に遷移先が決定していた場合はその遷移をキャンセルする
    /// </summary>
    protected bool TryChangeState(StateType type)
    {
        if (_stage == Stage.Enter || _stage == Stage.Exit)
        {
            Debug.LogError("Stay以外のStageから遷移不可能: " + type);
            return false;
        }

        _nextState = _controller.GetState(type);
        _stage = Stage.Exit;
        return true;
    }
}
