using UnityEngine;

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
        if (Controller.IsAllPlayerSelected())
        {
            Debug.Log("カード選択状態から遷移");
        }
    }
}
