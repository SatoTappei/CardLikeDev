using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトルで選択したゲームモードを表すための列挙型
/// </summary>
public enum GameMode
{
    CPU,
    Online,
}

/// <summary>
/// ゲーム全体を通して存在するのでシーンの遷移でも破棄されない
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] FadeModule _fadeModule;

    /// <summary>タイトルでボタンを押した際にゲームモードが決定される</summary>
    public GameMode CurrentGameMode { get; set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>フェードアウト後、シーンの遷移を行う</summary>
    public void SceneTransition(string nextScene)
    {
        _fadeModule.FadeOut(() => SceneManager.LoadScene(nextScene));
    }

    public void FadeIn()
    {
        _fadeModule.FadeIn();
    }
}
