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
        // ���҂��J�[�h�����肵���ꍇ�͔���̏�ԂɑJ�ڂ���
        if (Controller.IsAllPlayerSelected())
        {
            TryChangeState(StateType.Judge);
        }
    }
}
