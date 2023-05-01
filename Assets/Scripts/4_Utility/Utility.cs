/// <summary>
/// 便利クラス
/// </summary>
public static class Utility
{
    public static readonly string Player1CustomPropertyKey = "Player1";
    public static readonly string Player2CustomPropertyKey = "Player2";

    /// <summary>
    /// プレイヤー番号でカスタムプロパティのキーを取得したい場合はこのメソッドを呼び出すこと
    /// </summary>
    public static string GetPlayerCustomPropertyKey(int playerNum)
    {
        if (playerNum == 1)
        {
            return Player1CustomPropertyKey;
        }
        else if (playerNum == 2)
        {
            return Player2CustomPropertyKey; ;
        }
        else
        {
            throw new System.ArgumentOutOfRangeException("引数はプレイヤーの番号なので1もしくは2");
        }
    }
}
