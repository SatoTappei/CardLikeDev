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
        if (Controller.IsAllPlayerSelected())
        {
            Debug.Log("�J�[�h�I����Ԃ���J��");
        }
    }
}
