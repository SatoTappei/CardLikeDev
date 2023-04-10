using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �^�C�g���ŃQ�[�����[�h��I������{�^��
/// </summary>
public class GameModeSelectButton : ExtendButton
{
    [Header("�I������Q�[�����[�h")]
    [SerializeField] GameMode _gameMode;
    [Header("�J�ڐ�̃V�[���̖��O")]
    [SerializeField] string _nextSceneName;

    Button _button;

    void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    /// <summary>
    /// �I�������V�[���ɑJ�ڂ���
    /// </summary>
    public void OnClick()
    {
        _button.interactable = false;
        GameManager.Instance.SceneTransition(_nextSceneName);
        GameManager.Instance.CurrentGameMode = _gameMode;
    }
}
