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
        Debug.Log("カード選択状態");
    }
}
