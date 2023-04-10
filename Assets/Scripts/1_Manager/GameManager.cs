using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム全体を通して存在するのでシーンの遷移でも破棄されない
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] FadeModule _fadeModule;

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
