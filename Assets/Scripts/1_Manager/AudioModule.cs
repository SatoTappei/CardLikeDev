using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Đ����鉹���w�肷�邽�߂̗񋓌^
/// </summary>
public enum AudioType
{
    SE_Cancel
}

/// <summary>
/// �C���X�y�N�^�[���犄�蓖�Ă邽�߂̉��̃f�[�^
/// </summary>
[System.Serializable]
public class AudioData
{
    [SerializeField] AudioType _key;
    [SerializeField] AudioClip _clip;
    [SerializeField] float _volume;

    public AudioType Key => _key;
    public AudioClip Clip => _clip;
    public float Volume => _volume;
}

/// <summary>
/// ���̍Đ����s���N���X
/// </summary>
public class AudioModule
{
    /// <summary>�|���ɍĐ��ł��鉹�̐�</summary>
    static readonly int PlayAtSame = 10;
    /// <summary>�A���ōĐ��ł���Ԋu</summary>
    static readonly float Interval = 0.05f;

    AudioSource[] _audioSources = new AudioSource[PlayAtSame];
    Dictionary<AudioType, AudioData> _audioDict = new();

    float _lastTime;

    public AudioModule(GameObject gameObject, AudioData[] audioDatas)
    {
        for(int i = 0; i < _audioSources.Length; i++)
        {
            _audioSources[i] = gameObject.AddComponent<AudioSource>();
        }

        foreach(AudioData data in audioDatas)
        {
            _audioDict.Add(data.Key, data);
        }
    }

    public void PlaySE(AudioType type)
    {
        if (IsInterval()) return;

        AudioData data = GetData(type);
        AudioSource source = GetSourceSE();
        if (data == null || source == null) return;

        source.clip = data.Clip;
        source.volume = data.Volume;
        source.Play();
    }

    public void PlayBGM()
    {
        // ����ĂȂ�
    }

    bool IsInterval()
    {
        if (Time.realtimeSinceStartup - _lastTime > Interval)
        {
            _lastTime = Time.realtimeSinceStartup;
            return false;
        }
        else
        {
            return true;
        }
    }

    AudioSource GetSourceSE()
    {
        // ��Ԍ���AudioSource��BGM�Đ��p�Ȃ̂Ŏ���Ă���
        for(int i = 0; i < _audioSources.Length - 1; i++)
        {
            if (!_audioSources[i].isPlaying) return _audioSources[i];
        }

        Debug.LogWarning("AudioSource������Ȃ�");
        return null;
    }

    AudioData GetData(AudioType type)
    {
        if (_audioDict.TryGetValue(type, out AudioData data))
        {
            return data;
        }

        throw new KeyNotFoundException($"�����o�^����Ă��Ȃ�: {type}");
    }
}
