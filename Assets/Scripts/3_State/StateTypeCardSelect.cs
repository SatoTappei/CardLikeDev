using UnityEngine;

/// <summary>
/// �J�[�h��I��������
/// </summary>
public class StateTypeCardSelect : StateTypeBase
{
    public StateTypeCardSelect(InGameStream controller) : base(controller)
    {
    }

    protected override void Stay()
    {
        Debug.Log("�J�[�h�I�����");
    }
}
