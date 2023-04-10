using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �Q�[���S�̂�ʂ��đ��݂���̂ŃV�[���̑J�ڂł��j������Ȃ�
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

    /// <summary>�t�F�[�h�A�E�g��A�V�[���̑J�ڂ��s��</summary>
    public void SceneTransition(string nextScene)
    {
        _fadeModule.FadeOut(() => SceneManager.LoadScene(nextScene));
    }

    public void FadeIn()
    {
        _fadeModule.FadeIn();
    }
}
