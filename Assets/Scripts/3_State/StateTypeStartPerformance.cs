/// <summary>
/// バトル開始時の演出を行う状態
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
        // 演出後にカード選択状態に遷移する
        _startPerformance.Execute(() => TryChangeState(StateType.CardSelect));
    }
}
