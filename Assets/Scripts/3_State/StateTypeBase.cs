using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���̊e��Ԃ̊��N���X
/// �e��Ԃ͂��̃N���X���p�����č쐬����
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
    /// ���̏�ԂɑJ�ڂ���
    /// ��ɑJ�ڐ悪���肵�Ă����ꍇ�͂��̑J�ڂ��L�����Z������
    /// </summary>
    protected bool TryChangeState(StateType type)
    {
        if (_stage == Stage.Enter || _stage == Stage.Exit)
        {
            Debug.LogError("Stay�ȊO��Stage����J�ڕs�\: " + type);
            return false;
        }

        _nextState = _controller.GetState(type);
        _stage = Stage.Exit;
        return true;
    }
}
