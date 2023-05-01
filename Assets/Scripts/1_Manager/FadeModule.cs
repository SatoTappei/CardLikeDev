using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

/// <summary>
/// �V�[����J�ڂ���ۂ̃t�F�[�h���s���N���X
/// </summary>
public class FadeModule
{
    GameObject _gameObject;

    public FadeModule(GameObject gameObject)
    {
        _gameObject = gameObject;
    }

    public void FadeOut(UnityAction callback)
    {
        // TODO:�����ƍ��
        DOVirtual.DelayedCall(0.5f, () => callback?.Invoke())
            .OnStart(() => Debug.Log("�t�F�[�h�A�E�g���܂�"))
            .OnComplete(() => Debug.Log("�t�F�[�h�A�E�g�I��"))
            .SetLink(_gameObject);
    }

    public void FadeIn(UnityAction callback = null)
    {
        // TODO:�����ƍ��
        DOVirtual.DelayedCall(0.5f, () => callback?.Invoke())
            .OnStart(() => Debug.Log("�t�F�[�h�C�����܂�"))
            .OnComplete(() => Debug.Log("�t�F�[�h�C���I��"))
            .SetLink(_gameObject);
    }
}
