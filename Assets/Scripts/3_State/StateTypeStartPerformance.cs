/// <summary>
/// �o�g���J�n���̉��o���s�����
/// </summary>
public class StateTypeStartPerformance : StateTypeBase
{
    StartPerformance _startPerformance;

    public StateTypeStartPerformance(InGameStream controller, StartPerformance startPerformance)
        : base(controller) 
    {
        _startPerformance = startPerformance;
    }

    protected override void Enter()
    {
        // ���o��ɃJ�[�h�I����ԂɑJ�ڂ���
        _startPerformance.Execute(() => TryChangeState(StateType.CardSelect));
    }
}
