using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

/// <summary>
/// �V�[����J�ڂ���ۂ̃t�F�[�h���s��
/// </summary>
[System.Serializable]
public class FadeModule
{
    [SerializeField] GameObject gameObject;

    public void FadeOut(UnityAction callback)
    {
        // TODO:�����ƍ��
        DOVirtual.DelayedCall(0.5f, () => callback?.Invoke())
            .OnStart(() => Debug.Log("�t�F�[�h�A�E�g���܂�"))
            .OnComplete(() => Debug.Log("�t�F�[�h�A�E�g�I��"))
            .SetLink(gameObject);
    }

    public void FadeIn(UnityAction callback = null)
    {
        // TODO:�����ƍ��
        DOVirtual.DelayedCall(0.5f, () => callback?.Invoke())
            .OnStart(() => Debug.Log("�t�F�[�h�C�����܂�"))
            .OnComplete(() => Debug.Log("�t�F�[�h�C���I��"))
            .SetLink(gameObject);
    }
}
