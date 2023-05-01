/// <summary>
/// カードを選択する状態
/// </summary>
public class StateTypeCardSelect : StateTypeBase
{
    public StateTypeCardSelect(InGameStream controller) : base(controller)
    {
    }

    protected override void Stay()
    {
        // 両者がカードを決定した場合は判定の状態に遷移する
        if (Controller.IsAllPlayerSelected())
        {
            TryChangeState(StateType.Judge);
        }
    }
}
