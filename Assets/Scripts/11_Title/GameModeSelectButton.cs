using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// タイトルでゲームモードを選択するボタン
/// </summary>
public class GameModeSelectButton : ExtendButton
{
    [Header("遷移先のシーンの名前")]
    [SerializeField] string _nextSceneName;

    Button _button;

    void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    /// <summary>
    /// 選択したシーンに遷移する
    /// </summary>
    public void OnClick()
    {
        _button.interactable = false;
        GameManager.Instance.SceneTransition(_nextSceneName);
    }
}
