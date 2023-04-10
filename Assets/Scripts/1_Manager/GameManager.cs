using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �^�C�g���őI�������Q�[�����[�h��\�����߂̗񋓌^
/// </summary>
public enum GameMode
{
    CPU,
    Online,
}

/// <summary>
/// �Q�[���S�̂�ʂ��đ��݂���̂ŃV�[���̑J�ڂł��j������Ȃ�
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] FadeModule _fadeModule;

    /// <summary>�^�C�g���Ń{�^�����������ۂɃQ�[�����[�h�����肳���</summary>
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
